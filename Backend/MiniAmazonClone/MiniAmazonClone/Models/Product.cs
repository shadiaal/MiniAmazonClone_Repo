namespace MiniAmazonClone.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CreatedBy { get; set; } 
        public User? CreatedByUser { get; set; }// Many-to-one relationship 
        public List<OrderItem> OrderItems { get; set; }  // One-to-many relationship 
    }
}
