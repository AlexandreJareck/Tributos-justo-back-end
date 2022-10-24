using AppCrud.Business.Models;
using System.Transactions;

namespace AppCrud.Business.Interfaces.Services
{
    public interface IClientService : IDisposable
    {
        Task<Client?> Add(Client client);
        Task<Client?> Update(Client client);        
        Task Remove(Guid id);
    }
}
