using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Mimirorg.Authentication.Contracts;
using Mimirorg.Common.Exceptions;
using Mimirorg.Common.Models;
using Mimirorg.TypeLibrary.Enums;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Models;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Services.Services
{
    public class NodeService : INodeService
    {
        private readonly IMapper _mapper;
        private readonly INodeRepository _nodeRepository;
        private readonly IVersionService _versionService;
        private readonly ITimedHookService _hookService;
        private readonly ApplicationSettings _applicationSettings;

        public NodeService(IOptions<ApplicationSettings> applicationSettings, IVersionService versionService, IMapper mapper, INodeRepository nodeRepository, ITimedHookService hookService)
        {
            _versionService = versionService;
            _mapper = mapper;
            _nodeRepository = nodeRepository;
            _hookService = hookService;
            _applicationSettings = applicationSettings?.Value;
        }

        public async Task<NodeLibCm> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new MimirorgBadRequestException("Can't get node. The id is missing value.");

            var nodeDm = await _nodeRepository.Get(id);

            if (nodeDm == null)
                throw new MimirorgNotFoundException($"There is no node with id: {id}");

            var latestVersion = await _versionService.GetLatestVersion(nodeDm);

            if (latestVersion != null && nodeDm.Id != latestVersion.Id)
                throw new MimirorgBadRequestException($"The node with id {id} and version {nodeDm.Version} is older than latest version {latestVersion.Version}.");

            var nodeLibCm = _mapper.Map<NodeLibCm>(nodeDm);

            if (nodeLibCm == null)
                throw new MimirorgMappingException("NodeLibDm", "NodeLibCm");

            return nodeLibCm;
        }

        public async Task<IEnumerable<NodeLibCm>> GetLatestVersions()
        {
            var distinctFirstVersionIdDm = _nodeRepository.Get()?.ToList().DistinctBy(x => x.FirstVersionId).ToList();

            if (distinctFirstVersionIdDm == null || !distinctFirstVersionIdDm.Any())
                return await Task.FromResult(new List<NodeLibCm>());

            var nodes = new List<NodeLibDm>();

            foreach (var dm in distinctFirstVersionIdDm)
                nodes.Add(await _versionService.GetLatestVersion(dm));

            nodes = nodes.OrderBy(x => x.Aspect).ThenBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase).ToList();

            var nodeLibCms = _mapper.Map<List<NodeLibCm>>(nodes);

            if (nodes.Any() && (nodeLibCms == null || !nodeLibCms.Any()))
                throw new MimirorgMappingException("List<NodeLibDm>", "ICollection<NodeLibAm>");

            return await Task.FromResult(nodeLibCms ?? new List<NodeLibCm>());
        }

        public async Task<NodeLibCm> Create(NodeLibAm dataAm)
        {
            if (dataAm == null)
                throw new MimirorgBadRequestException("Data object can not be null.");

            var existing = await _nodeRepository.Get(dataAm.Id);

            if (existing != null)
                throw new MimirorgBadRequestException($"Node '{existing.Name}' with RdsCode '{existing.RdsCode}', Aspect '{existing.Aspect}' and version '{existing.Version}' already exist in db.");

            var nodeLibDm = _mapper.Map<NodeLibDm>(dataAm);

            if (!double.TryParse(nodeLibDm.Version, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _))
                throw new MimirorgBadRequestException($"Error when parsing version value '{nodeLibDm.Version}' to double.");

            if (nodeLibDm == null)
                throw new MimirorgMappingException("NodeLibAm", "NodeLibDm");

            await _nodeRepository.Create(nodeLibDm);
            _nodeRepository.ClearAllChangeTrackers();

            var dm = await Get(nodeLibDm.Id);

            if (dm != null)
                _hookService.HookQueue.Enqueue(CacheKey.AspectNode);

            return dm;
        }

        public async Task<NodeLibCm> Update(NodeLibAm dataAm, string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MimirorgBadRequestException("Can't update a node without an id.");

            if (dataAm == null)
                throw new MimirorgBadRequestException("Can't update a node when dataAm is null.");

            var nodeToUpdate = await _nodeRepository.Get(id);

            if (nodeToUpdate?.Id == null)
                throw new MimirorgNotFoundException($"Node with id {id} does not exist, update is not possible.");

            if (nodeToUpdate.CreatedBy == _applicationSettings.System)
                throw new MimirorgBadRequestException($"The node with id {id} is created by the system and can not be updated.");

            if (nodeToUpdate.Deleted)
                throw new MimirorgBadRequestException($"The node with id {id} is deleted and can not be updated.");

            var latestNodeDm = await _versionService.GetLatestVersion(nodeToUpdate);

            if (latestNodeDm == null)
                throw new MimirorgBadRequestException($"Latest node version for node with id {id} not found (null).");

            if (string.IsNullOrWhiteSpace(latestNodeDm.Version))
                throw new MimirorgBadRequestException($"Latest version for node with id {id} has null or empty as version number.");

            var latestNodeVersion = double.Parse(latestNodeDm.Version, CultureInfo.InvariantCulture);
            var nodeToUpdateVersion = double.Parse(nodeToUpdate.Version, CultureInfo.InvariantCulture);

            if (latestNodeVersion > nodeToUpdateVersion)
                throw new MimirorgBadRequestException($"Not allowed to update node with id {nodeToUpdate.Id} and version {nodeToUpdateVersion}. Latest version is node with id {latestNodeDm.Id} and version {latestNodeVersion}");

            var newVersion = await _versionService.CalculateNewVersion(latestNodeDm, dataAm);

            if (string.IsNullOrWhiteSpace(newVersion))
                return await Get(id);

            dataAm.Version = newVersion;
            dataAm.FirstVersionId = latestNodeDm.FirstVersionId;

            return await Create(dataAm);
        }

        public async Task<bool> Delete(string id)
        {
            var deleted = await _nodeRepository.Remove(id);

            if (deleted)
                _hookService.HookQueue.Enqueue(CacheKey.AspectNode);

            return deleted;
        }

        public async Task<bool> CompanyIsChanged(string nodeId, int companyId)
        {
            var node = await Get(nodeId);

            if (node == null)
                throw new MimirorgNotFoundException($"Couldn't find node with id: {nodeId}");

            return node.CompanyId != companyId;
        }
    }
}