using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email jest wymagany.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Proszę podać poprawny adres email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{5,}$", ErrorMessage = "Hasło nie spełnia wymagań.")]
        public string Password { get; set; }

        public int RoleId { get; set; } = 2;

        public virtual Role Role { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
