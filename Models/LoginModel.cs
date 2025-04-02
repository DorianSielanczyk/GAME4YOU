using System.ComponentModel.DataAnnotations;

namespace GAME4YOU.Entities
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Podaj Email aby się zalogować.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło aby się zalogować.")]
        public string Password { get; set; }
    }
}