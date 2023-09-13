using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPICrudNorthwind.Models;

namespace WebAPICrudNorthwind.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Create(TEntity entity);



        Task<TEntity?> Update(TEntity entity);



        Task Delete(TEntity entity);



        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null);



        Task<TEntity> GetById(int id);
    }
}
