using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Models;
using AppCrud.Data.Context;

namespace AppCrud.Data.Repository;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppCrudDbContext context) : base(context) { }
}
