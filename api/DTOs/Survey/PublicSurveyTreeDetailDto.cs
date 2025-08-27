using api.DTOs.QuestionType;
using api.DTOs.Option;
using api.DTOs.QuestionBranch;
using System.Text.Json.Serialization;

namespace api.DTOs.Survey
{
    // DTO c�y ch? d�ng cho PublicSurveyController
    public class PublicSurveyTreeDetailDto
    {
        public SurveyDto Survey { get; set; } = null!;
        public List<QuestionTreeNodeDto> RootQuestions { get; set; } = new();
    }

    public class QuestionTreeNodeDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Order { get; set; }
        public bool IsRequired { get; set; }
        public QuestionTypeDto QuestionType { get; set; } = null!;
        public List<OptionTreeNodeDto> Options { get; set; } = new();
        public int? ParentQuestionId { get; set; } // Th�m parentQuestionId ?? h? tr? flow frontend
    }

    public class OptionTreeNodeDto : OptionDto
    {
        public QuestionTreeNodeDto? NextQuestion { get; set; }
        public string? ConditionType { get; set; } // AND/OR cho nh�nh n?u c�
        public List<int>? BranchOptionIds { get; set; } // Danh s�ch optionId thu?c nh�nh n�y
    }
}
