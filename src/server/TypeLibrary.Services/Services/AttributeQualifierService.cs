﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Mimirorg.Common.Extensions;
using TypeLibrary.Data.Contracts;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Data;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Services.Services
{
    public class AttributeQualifierService : IAttributeQualifierService
    {
        private readonly IMapper _mapper;
        private readonly IQualifierRepository _qualifierRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public AttributeQualifierService(IMapper mapper, IQualifierRepository qualifierRepository, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _qualifierRepository = qualifierRepository;
            _contextAccessor = contextAccessor;
        }
        public Task<IEnumerable<AttributeQualifierLibAm>> GetAttributeQualifiers()
        {
            var dataList = _qualifierRepository.GetAll();
            var dataAm = _mapper.Map<List<AttributeQualifierLibAm>>(dataList);
            return Task.FromResult<IEnumerable<AttributeQualifierLibAm>>(dataAm);
        }

        public async Task<AttributeQualifierLibAm> UpdateAttributeQualifier(AttributeQualifierLibAm dataAm)
        {
            var data = _mapper.Map<AttributeQualifierLibDm>(dataAm);
            data.Updated = DateTime.Now.ToUniversalTime();
            data.UpdatedBy = _contextAccessor?.GetName() ?? "Unknown";
            _qualifierRepository.Update(data);
            await _qualifierRepository.SaveAsync();
            return _mapper.Map<AttributeQualifierLibAm>(data);
        }

        public async Task<AttributeQualifierLibAm> CreateAttributeQualifier(AttributeQualifierLibAm dataAm)
        {
            var data = _mapper.Map<AttributeQualifierLibDm>(dataAm);
            data.Created = DateTime.Now.ToUniversalTime();
            data.CreatedBy = _contextAccessor?.GetName() ?? "Unknown";
            var createdData = await _qualifierRepository.CreateAsync(data);
            await _qualifierRepository.SaveAsync();
            return _mapper.Map<AttributeQualifierLibAm>(createdData.Entity);
        }

        public async Task CreateAttributeQualifiers(List<AttributeQualifierLibAm> dataAm)
        {
            var dataList = _mapper.Map<List<AttributeQualifierLibDm>>(dataAm);
            var existing = _qualifierRepository.GetAll().ToList();
            var notExisting = dataList.Where(x => existing.All(y => y.Name != x.Name)).ToList();

            if (!notExisting.Any())
                return;

            foreach (var data in notExisting)
            {
                data.Created = DateTime.Now.ToUniversalTime();
                data.CreatedBy = _contextAccessor?.GetName() ?? "Unknown";
                _qualifierRepository.Attach(data, EntityState.Added);
            }

            await _qualifierRepository.SaveAsync();

            foreach (var data in notExisting)
                _qualifierRepository.Detach(data);
        }
    }
}