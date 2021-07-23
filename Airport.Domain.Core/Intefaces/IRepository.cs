
using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Domain.Core.Intefaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task SaveAsync();

        Task<TEntity> FindAsync(int id);

        Task<TEntity> FindAsync(Specification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSizen);

        Task AddAsync(TEntity entity);

        Task Update(TEntity entity);

        Task RemoveAsync(int entityId);
    }
}
