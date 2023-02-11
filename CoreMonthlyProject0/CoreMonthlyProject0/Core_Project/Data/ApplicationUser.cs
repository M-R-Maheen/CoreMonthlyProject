using Microsoft.AspNetCore.Identity;

namespace Core_Project.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Country { get; set; }
    }
}
