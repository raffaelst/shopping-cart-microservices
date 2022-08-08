using System.Collections.Generic;

namespace Microservices10.ShoppingCart.Mvc.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartModel> CartItems { get; set; }
    }

    public class ShoppingCartModel
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
