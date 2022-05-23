﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mimirorg.Common.Exceptions;
using Mimirorg.Common.Models;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using TypeLibrary.Data.Contracts.Ef;
using TypeLibrary.Data.Models;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Services.Services
{
    public class AttributeAspectService : IAttributeAspectService
    {
        private readonly IMapper _mapper;
        private readonly IEfAttributeAspectRepository _attributeAspectRepository;
        private readonly ApplicationSettings _applicationSettings;

        public AttributeAspectService(IMapper mapper, IEfAttributeAspectRepository attributeAspectRepository, IOptions<ApplicationSettings> applicationSettings)
        {
            _mapper = mapper;
            _attributeAspectRepository = attributeAspectRepository;
            _applicationSettings = applicationSettings?.Value;
        }

        public Task<IEnumerable<AttributeAspectLibCm>> GetAttributeAspects()
        {
            var allAttributes = _attributeAspectRepository.GetAll().Where(x => !x.Deleted).ToList();
            var attributes = allAttributes.Where(x => x.ParentId != null).ToList();
            var topParents = allAttributes.Where(x => x.ParentId == null).OrderBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase).ToList();

            var sortedAttributes = attributes.OrderBy(x => topParents
                .FirstOrDefault(y => y.Id == x.ParentId)?.Name, StringComparer.InvariantCultureIgnoreCase)
                .ThenBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase).ToList();

            sortedAttributes.AddRange(topParents);
            var dataCm = _mapper.Map<List<AttributeAspectLibCm>>(sortedAttributes);
            return Task.FromResult(dataCm.AsEnumerable());
        }

        public async Task<AttributeAspectLibCm> UpdateAttributeAspect(AttributeAspectLibAm dataAm, string id)
        {
            if (string.IsNullOrWhiteSpace(id) || dataAm == null)
                throw new MimirorgBadRequestException("The data object or id can not be null.");

            var existingDm = await _attributeAspectRepository.GetAsync(id);

            if (existingDm?.Id == null)
                throw new MimirorgBadRequestException("Object not found.");

            if (existingDm.CreatedBy == _applicationSettings.System)
                throw new MimirorgBadRequestException($"The object with id {id} is created by the system and can not be updated.");

            //TODO: The code below must be rewritten. What do we allow to be updated?
            var data = _mapper.Map<AttributeAspectLibDm>(dataAm);

            data.Id = id;
            _attributeAspectRepository.Update(data);
            await _attributeAspectRepository.SaveAsync();
            return _mapper.Map<AttributeAspectLibCm>(data);
        }

        public async Task<AttributeAspectLibCm> CreateAttributeAspect(AttributeAspectLibAm dataAm)
        {
            var data = _mapper.Map<AttributeAspectLibDm>(dataAm);
            var createdData = await _attributeAspectRepository.CreateAsync(data);
            await _attributeAspectRepository.SaveAsync();
            return _mapper.Map<AttributeAspectLibCm>(createdData.Entity);
        }

        public async Task CreateAttributeAspects(List<AttributeAspectLibAm> dataAm, bool createdBySystem = false)
        {
            var dataList = _mapper.Map<List<AttributeAspectLibDm>>(dataAm);
            var existing = _attributeAspectRepository.GetAll().ToList();
            var notExisting = dataList.Where(x => existing.All(y => y.Id != x.Id)).ToList();

            if (!notExisting.Any())
                return;

            foreach (var data in notExisting)
            {
                data.CreatedBy = createdBySystem ? _applicationSettings.System : data.CreatedBy;
                _attributeAspectRepository.Attach(data, EntityState.Added);
            }

            await _attributeAspectRepository.SaveAsync();

            foreach (var data in notExisting)
                _attributeAspectRepository.Detach(data);
        }
    }
}