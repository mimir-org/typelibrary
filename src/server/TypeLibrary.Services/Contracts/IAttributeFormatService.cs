﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;

namespace TypeLibrary.Services.Contracts
{
    public interface IAttributeFormatService
    {
        Task<IEnumerable<AttributeFormatLibCm>> GetAttributeFormats();
        Task<AttributeFormatLibCm> UpdateAttributeFormat(AttributeFormatLibAm dataAm, int id);
        Task<AttributeFormatLibCm> CreateAttributeFormat(AttributeFormatLibAm dataAm);
        Task CreateAttributeFormats(List<AttributeFormatLibAm> dataAm, bool createdBySystem = false);
    }
}