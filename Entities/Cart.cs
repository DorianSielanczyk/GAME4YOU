namespace GAME4YOU.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual Users User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
