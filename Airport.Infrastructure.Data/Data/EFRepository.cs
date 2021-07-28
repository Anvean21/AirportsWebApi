using Airport.Domain.Core.Entities;
using Airport.Domain.Core.Intefaces;
using Airport.Domain.Core.Models;
using Airport.Domain.Core.Specification;
using Airport.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> entities;

        public EFRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });

            await this.entities.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            this.entities.Update(entity);

            context.ChangeTracker.TrackGraph(entity, e =>
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
            });

            await this.context.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> FindAsync(Specification<TEntity> specification)
        {
            var includes = Include(specification);

            return await includes.FirstOrDefaultAsync(specification.Expression);
        }

        public async Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, int sorting, string property )
        {
            var includes = Include(specification);

            if (sorting == 0)
            {
                return await includes.Where(specification.Expression).OrderBy(x => x.Id).ToPagedListAsync(pageNumber, pageSize);
            }
            else 
            {
                //return await includes.Where(specification.Expression)
                //    .AsEnumerable()//Переключаемя на линкью
                //    .OrderByDescending(x => x.GetType().GetProperty(property).Name)
                //    .AsQueryable()
                //    .ToPagedListAsync(pageNumber, pageSize);
                return await includes.Where(specification.Expression).OrderByDescending(x => x.Id).ToPagedListAsync(pageNumber, pageSize);
            }
        }

        public async Task RemoveAsync(int entityId)
        {
            var deleteItem = await entities.FindAsync(entityId);

            entities.Remove(deleteItem);

            await this.context.SaveChangesAsync();
        }

        private IQueryable<TEntity> Include(Specification<TEntity> specification)
        {
            var query = entities.Where(x => true);

            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
