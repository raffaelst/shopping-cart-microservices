using AutoMapper;
using Orders.Application.Interface.DTO;
using Orders.Application.Interface.Interfaces;
using Orders.Domain.Entities;
using Orders.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public OrderItemDTO CreateOrderItem(OrderItemDTO orderItemDto)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDto);
            orderItem = _orderItemRepository.CreateOrderItem(orderItem);

            orderItemDto.OrderItemId = orderItem.OrderItemId;

            return orderItemDto;
        }
    }
}
