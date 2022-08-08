
using Orders.Application.Interface.DTO;

namespace Orders.Application.Interface.Interfaces
{
    public interface IOrderItemService
    {
        OrderItemDTO CreateOrderItem(OrderItemDTO orderItem);
    }
}
