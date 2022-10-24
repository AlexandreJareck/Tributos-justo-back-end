using AppCrud.Business.Models;
using AppCrud.Data.Context;

namespace AppCrud.Data.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppCrudDbContext context) : base(context) { }
}
