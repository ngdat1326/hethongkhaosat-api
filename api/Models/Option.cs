using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        [MaxLength(500)]
        public string Content { get; set; } = null!;
        [MaxLength(100)]
        public string? Value { get; set; }
    }
}
