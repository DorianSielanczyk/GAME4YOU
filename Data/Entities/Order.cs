using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual Users User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; } 

        public string Status { get; set; } = "Pending"; 

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
