using Microsoft.AspNetCore.Identity;

namespace EslProje.Models.Auth
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Email { get;set; }
        public string Password { get; set; }
        
        public bool IsActive { get;set; }
    }
}
