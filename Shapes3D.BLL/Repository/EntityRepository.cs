using Microsoft.EntityFrameworkCore;
using Shapes3D.BLL.Repository;
using Shapes3D.DAL.Context;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
             where TEntity : BaseEntity
    {
        protected internal StereometryContext _DbContext { get; set; }

        protected EntityRepository(StereometryContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task Add(TEntity entity)
        {
            await _DbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _DbContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return await _DbContext.Set<TEntity>().FirstOrDefaultAsync(expression);

        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _DbContext.Set<TEntity>().FirstAsync(e => e.Id == id);
        }

        public Task Remove(TEntity entity)
        {
            return Task.FromResult(_DbContext.Set<TEntity>().Remove(entity));
        }

        public Task Update(TEntity entity)
        {
            return Task.FromResult(_DbContext.Set<TEntity>().Update(entity));
        }
    }
}
