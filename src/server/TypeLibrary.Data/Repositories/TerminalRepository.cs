﻿using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Repositories
{
    public class TerminalRepository : GenericRepository<TypeLibraryDbContext, TerminalLibDm>, ITerminalRepository
    {
        public TerminalRepository(TypeLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
