
using ShoppingCart.Mvc.ViewModels;
using Microservices10.ShoppingCart.Mvc.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Mvc.RestClients
{
    public interface IOrderManagementApi
    {
        void CreateOrder(List<CheckoutItemModel> checkoutItemModels);
    }
}
