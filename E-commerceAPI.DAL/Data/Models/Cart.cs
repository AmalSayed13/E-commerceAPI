using E_commerceAPI.DAL.Data.Models;

public class Cart
{
    public int ID { get; set; }

    // Cart can be accessed by only one user 
    public string UserId { get; set; } = string.Empty;
    // Navigation property to the user
    public User? User { get; set; } 

    // Cart has many cart items
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
