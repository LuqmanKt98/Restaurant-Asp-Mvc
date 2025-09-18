using Microsoft.AspNetCore.Identity;

namespace WebRestoran.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order?> Orders { get; set; }

        public ApplicationUser()
        {
            Orders = new List<Order?>();
        }
    }
}
