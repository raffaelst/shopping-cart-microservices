using AutoMapper;
using Orders.Application.Interface.DTO;
using Orders.Application.Interface.Interfaces;
using Orders.Domain.Entities;
using Orders.Repository.Interface;

namespace Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        private const decimal ORDER_MAX_PRICE = 5000;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemService _orderItemService;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderItemService orderItemService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderItemService = orderItemService;
        }

        public OrderDTO CreateOrder(List<OrderItemDTO> orderitems)
        {
            OrderDTO orderDTO = new OrderDTO();

            if (orderitems != null && orderitems.Count > 0)
            {
                decimal total = orderitems.Sum(o => o.Quantity * o.Price);

                Order order = new Order();
                order.Total = total;
                order.Status = Status.AwaitingShipment;

                //TODO: Refactor logic
                if (total > ORDER_MAX_PRICE)
                {
                    throw new Exception("Order invalid");
                }

                order = _orderRepository.CreateOrder(order);

                orderDTO = _mapper.Map<OrderDTO>(order);

                foreach (var item in orderitems)
                {
                    item.OrderId = order.OrderId;
                    _orderItemService.CreateOrderItem(item);
                }
            }

            return orderDTO;
        }

        public OrderDTO CreateOrder(OrderDTO orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);

            order = _orderRepository.CreateOrder(order);

            orderDto.OrderId = order.OrderId;

            return orderDto;
        }

        public void UpdateOrder(OrderDTO orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);

            _orderRepository.UpdateOrder(order);
        }
    }
}
