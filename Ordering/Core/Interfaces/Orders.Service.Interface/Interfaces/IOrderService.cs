
using Orders.Application.Interface.DTO;

namespace Orders.Application.Interface.Interfaces
{
    public interface IOrderService
    {
        void UpdateOrder(OrderDTO order);
        OrderDTO CreateOrder(OrderDTO order);
        OrderDTO CreateOrder(List<OrderItemDTO> orderitems);
    }
}
