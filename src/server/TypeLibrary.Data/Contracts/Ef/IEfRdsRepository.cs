using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Contracts.Ef
{
    public interface IEfRdsRepository : IGenericRepository<TypeLibraryDbContext, RdsLibDm>, IRdsRepository
    {
    }
}