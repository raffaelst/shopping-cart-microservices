using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderRepository
    {
        private OrdersDbContext _context;

        public OrderRepository(OrdersDbContext context)
        {
            _context = context;
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Order CreateOrder(Order order)
        {
            order = _context.Add(order).Entity;
            _context.SaveChanges();

            return order;
        }
    }
}
