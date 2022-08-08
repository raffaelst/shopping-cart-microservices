using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public long OrderId { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
