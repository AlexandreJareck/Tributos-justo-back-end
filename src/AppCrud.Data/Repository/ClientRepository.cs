using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Models;
using AppCrud.Data.Context;

namespace AppCrud.Data.Repository;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AppCrudDbContext context) : base(context) { }
}
