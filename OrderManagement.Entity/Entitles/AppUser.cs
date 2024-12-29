using Microsoft.AspNetCore.Identity;

namespace OrderManagement.Entity.Entitles
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}