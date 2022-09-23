using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Context;
using ShoppingAPI.Model;

namespace ShoppingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dataContext.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product foundProduct = _dataContext.Products.FirstOrDefault(p => p.Id == id);
            if (foundProduct == null)
            {
                return BadRequest();
            }
            return Ok(foundProduct);
        }

        [HttpPost]
        public IEnumerable<Product> CreateProduct([FromBody] Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return _dataContext.Products.ToList();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Product> DeleteProduct(int id)
        {
            Product foundProduct = _dataContext.Products.FirstOrDefault(p => p.Id == id);
            if (foundProduct != null)
            {
                _dataContext.Products.Remove(foundProduct);
                _dataContext.SaveChanges();
            }
            return _dataContext.Products.ToList();
        }
    }
}
