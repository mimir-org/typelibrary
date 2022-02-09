﻿using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Contracts;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Data.Repositories
{
    public class AttributeQualifierRepository : GenericRepository<TypeLibraryDbContext, AttributeQualifierLibDm>, IQualifierRepository
    {
        public AttributeQualifierRepository(TypeLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}