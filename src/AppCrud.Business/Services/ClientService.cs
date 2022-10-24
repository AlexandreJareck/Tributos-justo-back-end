using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;

namespace AppCrud.Business.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository, INotifier notifier) : base(notifier)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Add(Client client)
        {
            if (!ExecuteValidation(new ClientValidation(), client))
                return null;

            await _clientRepository.Add(client);

            return client;
        }

        public Task<Client> Update(Client obj)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            await _clientRepository.Remove(id);
        }

        public Task<int> SaveChange()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
