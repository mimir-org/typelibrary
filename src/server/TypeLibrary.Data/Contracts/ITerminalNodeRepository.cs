﻿using Mimirorg.Common.Abstract;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Data.Contracts
{
    public interface ITerminalNodeRepository : IGenericRepository<TypeLibraryDbContext, TerminalNodeLibDm>
    {
    }
}