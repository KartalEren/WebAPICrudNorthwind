using WebAPICrudNorthwind.Models;
using WebAPICrudNorthwind.Repository.IRepository;

namespace WebAPICrudNorthwind.EntityRepository.Abstract
{
    public interface IProductRepository:IBaseRepository<Product>
    {
    }
}
