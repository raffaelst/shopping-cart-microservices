using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Repository.Interface
{
    public interface IOrderRepository
    {
        void UpdateOrder(Order order);
        Order CreateOrder(Order order);
    }
}
