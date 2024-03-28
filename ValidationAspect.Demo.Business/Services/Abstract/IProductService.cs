using Aspect.Demo.Business.DTOs;

namespace Aspect.Demo.Business.Services.Abstract
{
    public interface IProductService
    {
        bool CreateProduct(CreateProductDto productDto);
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        bool UpdateProduct(UpdateProductDto productDto);
        bool DeleteProduct(int id);
    }
}
