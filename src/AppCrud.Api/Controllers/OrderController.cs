using AppCrud.Api.DTOs;
using AppCrud.Business.Interfaces;
using AppCrud.Business.Interfaces.Repositories;
using AppCrud.Business.Interfaces.Services;
using AppCrud.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Api.Controllers
{
    [Route("api/pedidos")]
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderDTO>> Get(Guid id)
        {
            return _mapper.Map<OrderDTO>(await _orderRepository.GetById(id));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OrderDTO>> Update(Guid id, OrderDTO orderDTO)
        {
            if (id != orderDTO.Id)
            {
                NotifyErrors("Id inválido!");
                return CustomResponse(orderDTO);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _orderService.Update(_mapper.Map<Order>(orderDTO));

            return CustomResponse(orderDTO);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Add(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _orderService.Add(_mapper.Map<Order>(orderDTO));

            return CustomResponse(orderDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrderDTO>> Remove(Guid id)
        {
            var orderDTO = _mapper.Map<OrderDTO>(await _orderRepository.GetById(id));

            if (orderDTO == null)
                return NotFound();

            await _orderService.Remove(id);

            return CustomResponse();
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(OrderItem item)
        {
            //var order = await _orderRepository.GetById(item.OrderId);

            //if(order == null)
            //{
            //    var newOrder = new Order();
            //    newOrder.AddItem(item);

            //    await _orderService.Add(newOrder);

            //    return CustomResponse();
            //}

            //var existingItem = order.ExistingOrder(item);

            //if (existingItem)
            //{
            //    order.UpdateQuantity(item);
            //}
            //else
            //{
            //    order.AddItem(item);
            //}

            return CustomResponse();
        }
    }
}
