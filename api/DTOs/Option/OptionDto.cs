namespace api.DTOs.Option
{
    public class OptionDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public string? Value { get; set; }
    }
    public class CreateOptionDto
    {
        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public string? Value { get; set; }
    }
    public class UpdateOptionDto
    {
        public string? Content { get; set; }
        public string? Value { get; set; }
    }
}
