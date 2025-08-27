using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class QuestionBranchOption
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("QuestionBranch")]
        public int QuestionBranchId { get; set; }
        public QuestionBranch QuestionBranch { get; set; } = null!;
        [ForeignKey("Option")]
        public int OptionId { get; set; }
        public Option Option { get; set; } = null!;
    }
}
