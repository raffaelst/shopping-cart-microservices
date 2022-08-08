using Microservices10.ShoppingCart.Mvc.Models;
using System.Collections.Generic;

namespace Microservices10.ShoppingCart.Mvc.RestClients
{
    public interface IProductApi
    {
        List<ProductModel> GetProducts();
        List<ProductModel> GetPagedProducts(int pagesize, int page);
    }
}
