namespace api.DTOs.QuestionBranch
{
    public class QuestionBranchDto
    {
        public int Id { get; set; }
        public int CurrentQuestionId { get; set; }
        public int NextQuestionId { get; set; }
        public string ConditionType { get; set; } = "AND";
        public List<int> OptionIds { get; set; } = new();
    }
    public class CreateQuestionBranchDto
    {
        public int CurrentQuestionId { get; set; }
        public int NextQuestionId { get; set; }
        public string ConditionType { get; set; } = "AND";
        public List<int> OptionIds { get; set; } = new();
    }
    public class UpdateQuestionBranchDto
    {
        public int? CurrentQuestionId { get; set; }
        public int? NextQuestionId { get; set; }
        public string? ConditionType { get; set; }
        public List<int>? OptionIds { get; set; }
    }
}
