using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UserOtp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        [MaxLength(10)]
        public string OtpCode { get; set; } = null!;
        public DateTime Expiry { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
