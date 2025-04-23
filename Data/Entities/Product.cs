using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(50, ErrorMessage = "Tytuł może mieć maksymalnie 40 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(450, ErrorMessage = "Opis może mieć maksymalnie 450 znaków.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Range(0.01, 10000, ErrorMessage = "Cena musi być od 0.01 do 10 000 PLN.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana.")]
        [Range(1, 100, ErrorMessage = "Ilość musi być od 1 do 100 sztuk.")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        [Range(1, 5, ErrorMessage = "Wybierz kategorię.")]
        public int CategoryId { get; set; }

        public string? Key { get; set; }

        public string ImagePath { get; set; }
        public virtual Users User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Category Category { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
