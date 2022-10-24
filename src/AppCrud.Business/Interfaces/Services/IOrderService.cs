using AppCrud.Business.Models;

namespace AppCrud.Business.Interfaces.Services
{
    public interface IOrderService : IDisposable
    {
        Task<Order?> Add(Order order);
        Task<Order?> Update(Order order);
        Task Remove(Guid id);
    }
}
