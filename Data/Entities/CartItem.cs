using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAME4YOU.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; } // Klucz obcy do koszyka

        public int ProductId { get; set; } // Klucz obcy do produktu

        public int Quantity { get; set; } = 1; // Ilość dodanych sztuk

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
