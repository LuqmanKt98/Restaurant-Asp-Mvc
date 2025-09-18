using WebRestoran.Models;

namespace WebRestoran.Models.ViewModels
{
    public class UserManagementViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd > DateTimeOffset.Now;
    }

    public class UserDetailsViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public bool IsLockedOut => LockoutEnd.HasValue && LockoutEnd > DateTimeOffset.Now;
    }
}