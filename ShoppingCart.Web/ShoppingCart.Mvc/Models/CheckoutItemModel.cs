namespace Microservices10.ShoppingCart.Mvc.Models
{
    public class CheckoutItemModel
    {
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
