﻿using Mimirorg.Common.Abstract;
using TypeLibrary.Models.Data.TypeEditor;

namespace TypeLibrary.Data.Contracts
{
    public interface ITransportTypeRepository : IGenericRepository<TypeLibraryDbContext, TransportType>
    {
    }
}
