﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;

namespace TypeLibrary.Services.Contracts
{
    public interface IPurposeService
    {
        Task<IEnumerable<PurposeLibCm>> GetPurposes();
        Task CreatePurposes(List<PurposeLibAm> dataAm, bool createdBySystem = false);
    }
}