namespace MiniAmazonClone.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order? Order { get; set; }// Many-to-one relationship with Order
        public Product? Product { get; set; }// Many-to-one relationship with Product


     
    }
}
