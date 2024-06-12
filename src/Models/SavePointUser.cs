using Microsoft.AspNetCore.Identity;

namespace SavePointAPI.Models
{
    public class SavePointUser : IdentityUser
    {
        public int SavePointUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}