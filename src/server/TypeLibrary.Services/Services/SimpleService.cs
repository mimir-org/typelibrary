﻿

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mimirorg.Common.Exceptions;
using Mimirorg.Common.Extensions;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Models;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Services.Services
{
    public class SimpleService : ISimpleService
    {
        private readonly IMapper _mapper;
        private readonly ISimpleRepository _simpleRepository;
        private readonly IAttributeRepository _attributeRepository;

        public SimpleService(IMapper mapper, ISimpleRepository simpleRepository, IAttributeRepository attributeRepository)
        {
            _mapper = mapper;
            _simpleRepository = simpleRepository;
            _attributeRepository = attributeRepository;
        }

        public async Task<SimpleLibCm> GetSimple(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new MimirorgBadRequestException("Can't get simple. The id is missing value.");

            var data = await _simpleRepository.FindSimple(id).FirstOrDefaultAsync();

            if (data == null)
                throw new MimirorgNotFoundException($"There is no simple with id: {id}");

            var simpleLibCm = _mapper.Map<SimpleLibCm>(data);

            if (simpleLibCm == null)
                throw new MimirorgMappingException("SimpleLibDm", "SimpleLibCm");

            return simpleLibCm;
        }

        public Task<IEnumerable<SimpleLibCm>> GetAllSimple()
        {
            var simpleLibDms = _simpleRepository.GetAllSimples().ToList();
            var simpleLibCms = _mapper.Map<IEnumerable<SimpleLibCm>>(simpleLibDms);

            if (simpleLibDms.Any() && (simpleLibCms == null || !simpleLibCms.Any()))
                throw new MimirorgMappingException("List<SimpleLibDm>", "ICollection<SimpleLibAm>");

            return Task.FromResult(simpleLibCms ?? new List<SimpleLibCm>());
        }
       
        public async Task<SimpleLibCm> CreateSimple(SimpleLibAm simpleAm)
        {
            var validation = simpleAm.ValidateObject();
            if (!validation.IsValid)
                throw new MimirorgBadRequestException("Couldn't create simple", validation);

            var s = await _simpleRepository.GetAsync(simpleAm.Id);
            if (s != null)
                throw new MimirorgDuplicateException($"There is already a simple with name: {simpleAm.Name}");

            var dmObject = _mapper.Map<SimpleLibDm>(simpleAm);
            if (dmObject == null)
                throw new MimirorgMappingException(nameof(SimpleLibAm), nameof(SimpleLibDm));


            _attributeRepository.Attach(dmObject.Attributes, EntityState.Unchanged);
            await _simpleRepository.CreateAsync(dmObject);
            await _simpleRepository.SaveAsync();
            _attributeRepository.Detach(dmObject.Attributes);
            _simpleRepository.Detach(dmObject);

            var cm = _mapper.Map<SimpleLibCm>(dmObject);
            if (cm == null)
                throw new MimirorgMappingException(nameof(SimpleLibDm), nameof(SimpleLibCm));

            return cm;
        }

        public async Task<IEnumerable<SimpleLibCm>> CreateSimple(IEnumerable<SimpleLibAm> simpleAmList)
        {
            var simpleCms = new List<SimpleLibCm>();

            if (simpleAmList == null)
                return simpleCms;

            foreach (var simpleAm in simpleAmList.ToList())
            {
                var validation = simpleAm.ValidateObject();
                if (!validation.IsValid)
                    throw new MimirorgBadRequestException("Couldn't create simple", validation);

                var s = await _simpleRepository.GetAsync(simpleAm.Id);
                if (s != null)
                    continue;

                var dmObject = _mapper.Map<SimpleLibDm>(simpleAm);

                if (dmObject == null)
                    throw new MimirorgMappingException(nameof(SimpleLibAm), nameof(SimpleLibDm));

                simpleCms.Add(_mapper.Map<SimpleLibCm>(dmObject));

                _attributeRepository.Attach(dmObject.Attributes, EntityState.Unchanged);
                await _simpleRepository.CreateAsync(dmObject);
                await _simpleRepository.SaveAsync();
                _attributeRepository.Detach(dmObject.Attributes);
                _simpleRepository.Detach(dmObject);
            }

            return simpleCms;
        }

        public void ClearAllChangeTrackers()
        {
            _simpleRepository?.Context?.ChangeTracker.Clear();
            _attributeRepository?.Context?.ChangeTracker.Clear();
        }
    }
}