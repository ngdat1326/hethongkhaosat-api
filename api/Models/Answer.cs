using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Response")]
        public int ResponseId { get; set; }
        public Response Response { get; set; } = null!;
        [ForeignKey("Question")]
        public int? QuestionId { get; set; } 
        public Question? Question { get; set; } = null!;
        [ForeignKey("Option")]
        public int? OptionId { get; set; } 
        public Option? Option { get; set; }
        [MaxLength(1000)]
        public string? TextAnswer { get; set; } 
        public string? ExtraOptionIds { get; set; } 
        [MaxLength(1000)]
        public string? QuestionContent { get; set; } 
        [MaxLength(1000)]
        public string? AnswerContent { get; set; } 
        public int? QuestionIdBackup { get; set; } 
        public int? OptionIdBackup { get; set; }
        public string? ExtraOptionIdsBackup { get; set; }
    }
}
