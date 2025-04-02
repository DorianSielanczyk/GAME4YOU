using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(450)]
        public string Description { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

        public int CategoryId { get; set; } 

        public string? Key { get; set; }

        public string ImagePath { get; set; }
        public virtual Users User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Category Category { get; set; }

    }
}
