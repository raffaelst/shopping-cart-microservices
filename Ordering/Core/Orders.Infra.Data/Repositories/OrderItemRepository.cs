using Orders.Domain.Entities;
using Orders.Infra.Data.Context;
using Orders.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infra.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private OrdersDbContext _context;

        public OrderItemRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public OrderItem CreateOrderItem(OrderItem orderItem)
        {
            orderItem = _context.Add(orderItem).Entity;
            _context.SaveChanges();

            return orderItem;
        }
    }
}
