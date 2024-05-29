using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class UserModel
    {
        public int Userid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
