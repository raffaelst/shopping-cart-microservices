using PagedList.Core;
using System.Collections.Generic;

namespace Microservices10.ShoppingCart.Mvc.Models
{
    public class ProductsViewModel
    {
        public PagedList<ProductModel> Products { get; set; }
    }

    public class ProductModel
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Thumbnail { get; set; }
    }
}
