using AppCrud.Api.DTOs;
using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Api.Controllers
{
    [Route("api/clientes")]
    public class ClientController : MainController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(INotifier notifier,
                                  IClientRepository clientRepository,
                                  IClientService clientService,
                                  IMapper mapper) : base(notifier)
        {
            _clientRepository = clientRepository;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ClientDTO>> Get(Guid id)
        {
            return _mapper.Map<ClientDTO>(await _clientRepository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> Add(ClientDTO clientDTO)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _clientService.Add(_mapper.Map<Client>(clientDTO));

            return CustomResponse(clientDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ClientDTO>> Update(Guid id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                NotifyErrors("Id inválido!");
                return CustomResponse(clientDTO);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _clientService.Update(_mapper.Map<Client>(clientDTO));

            return CustomResponse(clientDTO);
        }

        [HttpDelete]
        public async Task<ActionResult<ClientDTO>> Remove(Guid id)
        {
            var clientDTO = _mapper.Map<ClientDTO>(await _clientRepository.GetById(id));

            if (clientDTO == null)
                return NotFound();

            await _clientService.Remove(id);

            return CustomResponse();
        }
    }
}
