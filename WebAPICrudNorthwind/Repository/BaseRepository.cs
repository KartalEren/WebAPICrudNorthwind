using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPICrudNorthwind.Models;
using WebAPICrudNorthwind.Repository.IRepository;

namespace WebAPICrudNorthwind.Repository
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : NorthwindContext
    {
        private readonly TContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(TContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }



        public async Task<TEntity?> Create(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            return await _db.SaveChangesAsync() > 0 ? entity : null;

        }

        public async Task Delete(TEntity entity)
        {
             _dbSet.Remove(entity);
            _db.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity?> Update(TEntity entity)
        {
            using (var context =new NorthwindContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0 ? entity : null;

            }
        }
    }
}
