﻿using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Contracts;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Data.Repositories
{
    public class BlobRepository : GenericRepository<TypeLibraryDbContext, BlobLibDm>, IBlobDataRepository
    {
        public BlobRepository(TypeLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
