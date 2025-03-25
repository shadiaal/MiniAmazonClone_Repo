namespace MiniAmazonClone.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // Admin or Customer
        public List<Order>? Orders { get; set; }// One-to-many relationship 
    }
}
