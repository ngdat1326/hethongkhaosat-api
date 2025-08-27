using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; } = null!;
        [MaxLength(100)]
        public string? RespondentId { get; set; } // m� b?nh nh�n, userId ho?c m� ?n danh
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        // Th�ng tin chung
        [MaxLength(200)]
        public string? FullName { get; set; }
        [MaxLength(200)]
        public string? Position { get; set; }
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }
        [MaxLength(200)]
        public string? CompanyName { get; set; }
    }
}
