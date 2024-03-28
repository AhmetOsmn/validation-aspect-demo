using Microsoft.AspNetCore.Mvc;
using ValidationAspect.Demo.Business.DTOs;
using ValidationAspect.Demo.Business.Services.Abstract;

namespace ValidationAspect.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isCreated = _productService.CreateProduct(productDto);
            if (isCreated)
            {
              
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error Occured.");
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.Id)
            {
                return BadRequest("Invalid Id.");
            }

            var isUpdated = _productService.UpdateProduct(productDto);
            if (isUpdated)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productService.DeleteProduct(id);
            if (isDeleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
