using WebAPICrudNorthwind.EntityRepository.Abstract;
using WebAPICrudNorthwind.Models;
using WebAPICrudNorthwind.Repository;

namespace WebAPICrudNorthwind.EntityRepository.Concreate
{
    public class ProductRepository : BaseRepository<Product, NorthwindContext>, IProductRepository
    {
        public ProductRepository(NorthwindContext db) : base(db)
        {
        }
    }
}
