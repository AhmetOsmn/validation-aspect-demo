using Aspect.Demo.Business.DTOs;
using Aspect.Demo.Business.Validation.FluentValidation;
using Aspect.Demo.Business.Validation.FluentValidation.Product;
using Aspect.Demo.Core.Aspects.Autofac.Validation;
using Aspect.Demo.DataAccess.Entities;
using Aspect.Demo.DataAccess.Repositories.Abstract;

namespace Aspect.Demo.Business.Services.Abstract
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productRepository.GetAll().Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Description, p.CreatedDate));
        }

        [ValidationAspect(typeof(CreateProductDtoValidator))]
        public bool CreateProduct(CreateProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    CreatedDate = DateTime.Now
                };

                _productRepository.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ValidationAspect(typeof(IdValidator))]
        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return null;
            return new ProductDto(product.Id, product.Name, product.Price, product.Description, product.CreatedDate);
        }

        [ValidationAspect(typeof(UpdateProductDtoValidator))]
        public bool UpdateProduct(UpdateProductDto productDto)
        {
            try
            {
                var existingProduct = _productRepository.GetById(productDto.Id);
                if (existingProduct == null) return false;

                existingProduct.Name = productDto.Name;
                existingProduct.Description = productDto.Description;
                existingProduct.Price = productDto.Price;

                _productRepository.Update(existingProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ValidationAspect(typeof(IdValidator))]
        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product == null) return false;

                _productRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
