using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Interface.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderItems = new List<OrderItemDTO>();
        }
        public long OrderId { get; set; }
        public decimal Total { get; set; }
        public StatusDTO Status { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
