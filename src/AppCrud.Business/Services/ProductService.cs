using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;

namespace AppCrud.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }
        public async Task<Product?> Add(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product))
                return null;

            await _productRepository.Add(product);

            return product;
        }
        public async Task Remove(Guid id)
        {
            await _productRepository.Remove(id);
        }
        public async Task<Product?> Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product))
                return null;

            await _productRepository.Update(product);

            return product;
        }
        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
