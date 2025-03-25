namespace MiniAmazonClone.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Shipped, Delivered
        public User? User { get; set; }// Many-to-one relationship with User
        public List<OrderItem>? OrderItems { get; set; } // One-to-many relationship with OrderItems

        public DateTime? RefundDate { get; set; } 

    }
}

