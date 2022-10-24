using AppCrud.Business.Models;

namespace AppCrud.Business.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product?> Add(Product client);
        Task<Product?> Update(Product client);
        Task Remove(Guid id);
    }
}
