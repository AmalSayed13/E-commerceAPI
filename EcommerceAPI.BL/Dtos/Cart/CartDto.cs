namespace E_commerceAPI.BL.Dtos.Cart
{
    public class CartDto
    {
        public int ID { get; set; }

        // Cart can be accessed by only one user 
        public string UserId { get; set; } = string.Empty;

        public ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

    }
}
