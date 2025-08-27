using System.Collections.Generic;

namespace api.DTOs.Survey
{
    public class SurveyAnalyticsQuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int TotalAnswers { get; set; }
        // SingleChoice/MultiChoice
        public List<SurveyAnalyticsOptionDto>? Options { get; set; }
        // Rating/Scale
        public double? Average { get; set; }
        public Dictionary<string, int>? Counts { get; set; }
        // Text
        public List<string>? Answers { get; set; }
    }

    public class SurveyAnalyticsOptionDto
    {
        public int OptionId { get; set; }
        public string Content { get; set; } = null!;
        public int Count { get; set; }
        public double Percent { get; set; }
    }
}
