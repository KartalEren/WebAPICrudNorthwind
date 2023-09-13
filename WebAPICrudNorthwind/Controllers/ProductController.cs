using Microsoft.AspNetCore.Mvc;
using WebAPICrudNorthwind.EntityRepository.Abstract;
using WebAPICrudNorthwind.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICrudNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }

        
         
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _productRepository.GetAll(x => x.ProductId != null);
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]//listeleme
        public async Task<Product> Get(int id)
        {
            var products = await _productRepository.GetById(id);
            return products;
        }

        // POST api/<ProductController>
        [HttpPost]//oluşturma
        public async Task<IActionResult> Post([FromBody] Product product)
        {
           var products= await _productRepository.Create(product);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // PUT api/<ProductController>/5
        [HttpPut]//güncelleme
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            var updateProduct = await _productRepository.Update(product);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(updateProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]//silme
        public async Task<IActionResult> Delete(int id)
        {
            var deletedProduct= await _productRepository.GetById(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }

            await _productRepository.Delete(deletedProduct);

            return Ok();
        }
    }
}
