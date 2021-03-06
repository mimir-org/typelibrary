using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Contracts.Ef;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Repositories.Ef
{
    public class EfNodeTerminalRepository : GenericRepository<TypeLibraryDbContext, NodeTerminalLibDm>, IEfNodeTerminalRepository
    {
        public EfNodeTerminalRepository(TypeLibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}