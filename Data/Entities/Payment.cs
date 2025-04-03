using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public decimal Amount { get; set; } 

        public string PaymentMethod { get; set; }

        public string Status { get; set; } = "Pending"; 

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
}
