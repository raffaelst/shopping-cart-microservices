using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Mvc.Models;
using MassTransit;
using PagedList.Core;
using Microservices10.ShoppingCart.Mvc.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microservices10.ShoppingCart.Mvc.RestClients;

namespace ShoppingCart.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusControl _busControl;
        readonly IPublishEndpoint _publishEndpoint;
        private readonly IProductApi _productApi;

        public HomeController(ILogger<HomeController> logger, IBusControl busControl,IPublishEndpoint publishEndpoint, IProductApi productApi)
        {
            _logger = logger; 
            _publishEndpoint = publishEndpoint;
            _busControl = busControl;
            _productApi = productApi;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            ProductsViewModel productsViewModel = new ProductsViewModel();


            //TODO: Improve paging logic
            //List<ProductModel> productModels = _productApi.GetPagedProducts(pageSize, pageNumber);
            List<ProductModel> productModels = _productApi.GetProducts();
            PagedList<ProductModel> products = new PagedList<ProductModel>(productModels.AsQueryable(), pageNumber, pageSize);

            productsViewModel.Products = products;

            return View(productsViewModel);
        }

        public IActionResult AddToCart(int productId, string title, decimal price, int? page)
        {
            ShoppingCartModel product = new ShoppingCartModel { ProductId = productId, Title = title, Price = price };
            var value = HttpContext.Session.Get("cartItems");

            List<ShoppingCartModel> currentProductsSession = new List<ShoppingCartModel>();

            if (value != null)
            {
                currentProductsSession = JsonSerializer.Deserialize<List<ShoppingCartModel>>(value);
            }

            List<ShoppingCartModel> newProductsSession = new List<ShoppingCartModel>();
            newProductsSession.AddRange(currentProductsSession);

            ShoppingCartModel shoppingCartFound = newProductsSession.FirstOrDefault(p => p.ProductId == productId);

            if (shoppingCartFound == null)
            {
                product.Quantity = 1;
                newProductsSession.Add(product);
            }
            else
            {
                shoppingCartFound.Quantity += 1;
            }

            HttpContext.Session.Set("cartItems", JsonSerializer.SerializeToUtf8Bytes(newProductsSession, new JsonSerializerOptions(new JsonSerializerDefaults())));

            return RedirectToAction("Index", "Home", new { page  = page });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
