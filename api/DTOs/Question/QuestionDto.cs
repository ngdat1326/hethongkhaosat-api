namespace api.DTOs.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Content { get; set; } = null!;
        public int QuestionTypeId { get; set; }
        public int Order { get; set; }
        public bool IsRequired { get; set; }
    }
    public class CreateQuestionDto
    {
        public int SurveyId { get; set; }
        public string Content { get; set; } = null!;
        public int QuestionTypeId { get; set; }
        public int Order { get; set; }
        public bool IsRequired { get; set; } = false;
    }
    public class UpdateQuestionDto
    {
        public string? Content { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? Order { get; set; }
        public bool? IsRequired { get; set; }
    }
}
