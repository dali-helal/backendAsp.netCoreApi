using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class AppUser : IdentityUser
    {
      
        public string LastName { get; set; }=String.Empty;
        public string Job { get; set; } = String.Empty;
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
