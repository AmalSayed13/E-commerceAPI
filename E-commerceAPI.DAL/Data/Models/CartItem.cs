using E_commerceAPI.DAL.Data.Models;

public class CartItem
{
    public int ID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }

    // Cart item belongs to one cart
    public int CartId { get; set; } // This should correctly reference the Cart
    public Cart? Cart { get; set; } // Navigation property to the cart

    // Cart item belongs to one product
    public int ProductId { get; set; } // This should correctly reference the Product
    public Product? Product { get; set; } // Navigation property to the product
}
