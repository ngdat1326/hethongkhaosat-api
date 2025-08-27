using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsEmailVerified { get; set; } = false; // Thêm trường xác thực email
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}