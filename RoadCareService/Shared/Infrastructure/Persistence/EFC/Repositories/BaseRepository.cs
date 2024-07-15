using Microsoft.EntityFrameworkCore;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository<TEntity>(RoadCareContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly RoadCareContext Context = context;

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
        public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
        public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);
    }
}