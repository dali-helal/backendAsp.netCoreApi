using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; } 
    }
}
