using ValidationAspect.Demo.DataAccess.Entities;

namespace ValidationAspect.Demo.DataAccess.Repositories.Abstract
{
    public interface IProductRepository
    {
        Product Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Update(Product product);
        void Delete(int id);
    }
}
