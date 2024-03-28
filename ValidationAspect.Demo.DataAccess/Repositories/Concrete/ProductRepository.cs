using ValidationAspect.Demo.DataAccess.Entities;
using ValidationAspect.Demo.DataAccess.Repositories.Abstract;

namespace ValidationAspect.Demo.DataAccess.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public Product Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            product.CreatedDate = DateTime.Now;
            _products.Add(product);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found", nameof(product));
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            // CreatedDate güncellenmez, çünkü bu, ürün oluşturulduğunda atanır ve değişmez.
            return existingProduct;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
