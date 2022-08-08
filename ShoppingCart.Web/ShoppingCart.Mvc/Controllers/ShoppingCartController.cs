using ShoppingCart.Mvc.Controllers;
using ShoppingCart.Mvc.RestClients;
using MassTransit;
using Microservices10.ShoppingCart.Mvc.Models;
using Microservices10.ShoppingCart.Mvc.RestClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;

namespace Microservices10.ShoppingCart.Mvc.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderManagementApi _orderManagementApi;

        public ShoppingCartController(IOrderManagementApi orderManagementApi)
        {
            _orderManagementApi = orderManagementApi;
        }

        public IActionResult Index()
        {
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();

            var value = HttpContext.Session.Get("cartItems");

            List<ShoppingCartModel> currentProductsSession = new List<ShoppingCartModel>();

            if (value != null)
            {
                currentProductsSession = JsonSerializer.Deserialize<List<ShoppingCartModel>>(value);
            }

            shoppingCartViewModel.CartItems = currentProductsSession;

            return View(shoppingCartViewModel);
        }

        public IActionResult Buy()
        {
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();

            var value = HttpContext.Session.Get("cartItems");

            List<ShoppingCartModel> currentProductsSession = new List<ShoppingCartModel>();

            if (value != null)
            {
                currentProductsSession = JsonSerializer.Deserialize<List<ShoppingCartModel>>(value);

                if (currentProductsSession != null && currentProductsSession.Count > 0)
                {
                    List<CheckoutItemModel> currentCheckoutItems = new List<CheckoutItemModel>();

                    foreach (ShoppingCartModel item in currentProductsSession)
                    {
                        CheckoutItemModel checkoutItemModel = new CheckoutItemModel();
                        checkoutItemModel.ProductId = item.ProductId;
                        checkoutItemModel.Quantity = item.Quantity;
                        checkoutItemModel.Price = item.Price;

                        currentCheckoutItems.Add(checkoutItemModel);
                    }

                    _orderManagementApi.CreateOrder(currentCheckoutItems);
                }
            }

            HttpContext.Session.Remove("cartItems");

            return RedirectToAction("Index", "Home");
        }
    }
}
