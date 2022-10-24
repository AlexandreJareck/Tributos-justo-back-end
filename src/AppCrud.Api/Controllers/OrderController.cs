using AppCrud.Api.DTOs;
using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;
using AppCrud.Business.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Api.Controllers
{
    public class OrderController : MainController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(INotifier notifier,
                              IOrderRepository orderRepository,
                              IOrderService orderService,
                              IMapper mapper) : base(notifier)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{guid:id}")]
        public async Task<ActionResult<OrderDTO>> Get(Guid id)
        {
            return _mapper.Map<OrderDTO>(await _orderRepository.GetById(id));
        }

        [HttpPut]
        public async Task<ActionResult<OrderDTO>> Update(Guid id, OrderDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                NotifyErrors("Id inválido!");
                return CustomResponse(productDTO);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _orderService.Update(_mapper.Map<Order>(productDTO));

            return CustomResponse(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Add(OrderDTO clientDTO)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _orderService.Add(_mapper.Map<Order>(clientDTO));

            return CustomResponse(clientDTO);
        }
    }
}
