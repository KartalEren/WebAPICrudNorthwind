using WebAPICrudNorthwind.EntityRepository.Abstract;
using WebAPICrudNorthwind.EntityRepository.Concreate;
using WebAPICrudNorthwind.Models;
using WebAPICrudNorthwind.Repository;

namespace WebAPICrudNorthwind.EntityRepository.Concreate
{
    public class CategoryRepository : BaseRepository<Category, NorthwindContext>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext db) : base(db)
        {
        }
    }
}
