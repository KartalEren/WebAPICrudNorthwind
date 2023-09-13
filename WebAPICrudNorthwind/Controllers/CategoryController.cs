using Microsoft.AspNetCore.Mvc;
using WebAPICrudNorthwind.EntityRepository.Abstract;
using WebAPICrudNorthwind.EntityRepository.Concreate;
using WebAPICrudNorthwind.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICrudNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CaegoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get() //listeleme
        {
            var category = await _categoryRepository.GetAll(x=>x.CategoryId!=null);
            return category;
        }

        // GET api/<CaegoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            var categories = await _categoryRepository.GetById(id);
            return categories;
        }

        // POST api/<CaegoryController>
        [HttpPost]//oluşturma
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var categories = await _categoryRepository.Create(category);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(categories);
        }

        // PUT api/<CaegoryController>/5
        [HttpPut("{id}")]//güncelleme
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var updateCategory = await _categoryRepository.Update(category);
            if (updateCategory == null)
            {
                return BadRequest();
            }
            return Ok(updateCategory);
        }

        // DELETE api/<CaegoryController>/5
        [HttpDelete("{id}")]//silme
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = await _categoryRepository.GetById(id);
            if (deletedCategory == null)
            {
                return BadRequest();
            }
            await _categoryRepository.Delete(deletedCategory);
            return Ok();
        }
    }
}
