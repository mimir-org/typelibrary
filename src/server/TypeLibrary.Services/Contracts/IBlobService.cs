﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Services.Contracts
{
    public interface IBlobService
    {
        Task<BlobLibDm> CreateBlob(BlobLibAm blob, bool saveData = true);
        Task<IEnumerable<BlobLibDm>> CreateBlob(IEnumerable<BlobLibAm> blobDataList);
        Task<BlobLibDm> UpdateBlob(BlobLibAm blob);
        IEnumerable<BlobLibAm> GetBlob();
    }
}