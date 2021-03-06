using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mimirorg.Common.Abstract;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Contracts.Ef;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Repositories.Ef
{
    public class EfAttributeRepository : GenericRepository<TypeLibraryDbContext, AttributeLibDm>, IEfAttributeRepository
    {
        private readonly IUnitRepository _unitRepository;

        public EfAttributeRepository(TypeLibraryDbContext dbContext, IUnitRepository unitRepository) : base(dbContext)
        {
            _unitRepository = unitRepository;
        }

        /// <summary>
        /// Get all attributes
        /// </summary>
        /// <returns>A collection of attributes</returns>
        /// <remarks>Only attributes that is not deleted will be returned</remarks>
        public IEnumerable<AttributeLibDm> Get()
        {
            return GetAll().Where(x => !x.Deleted).Include(x => x.Units);
        }

        /// <summary>
        /// Create a new attribute
        /// </summary>
        /// <param name="attribute">The attribute that should be created</param>
        /// <returns>An attribute</returns>
        public async Task<AttributeLibDm> Create(AttributeLibDm attribute)
        {
            _unitRepository.SetUnchanged(attribute.Units);
            await CreateAsync(attribute);
            await SaveAsync();
            _unitRepository.SetDetached(attribute.Units);
            Detach(attribute);
            return attribute;
        }

        public void SetUnchanged(ICollection<AttributeLibDm> items)
        {
            Attach(items, EntityState.Unchanged);
        }

        public void SetDetached(ICollection<AttributeLibDm> items)
        {
            Detach(items);
        }

        public void ClearAllChangeTrackers()
        {
            _unitRepository.ClearAllChangeTrackers();
            Context?.ChangeTracker.Clear();
        }
    }
}