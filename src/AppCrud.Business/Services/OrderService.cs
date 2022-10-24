using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;

namespace AppCrud.Business.Services;

public class OrderService : BaseService, IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository, INotifier notifier) : base(notifier)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order?> Add(Order order)
    {
        await _orderRepository.Add(order);

        return order;
    }
    public async Task<Order?> Update(Order order)
    {
        await _orderRepository.Update(order);

        return order;
    }

    public async Task Remove(Guid id)
    {
        await _orderRepository.Remove(id);
    }

    public void Dispose()
    {
        _orderRepository?.Dispose();
    }

}
