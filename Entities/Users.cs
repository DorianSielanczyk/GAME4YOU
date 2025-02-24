using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; } = 2;

        public virtual Role Role { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
