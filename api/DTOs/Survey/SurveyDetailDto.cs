using api.DTOs.QuestionType;
using api.DTOs.Option;
using api.DTOs.QuestionBranch;

namespace api.DTOs.Survey
{
    public class SurveyDetailDto
    {
        public SurveyDto Survey { get; set; } = null!;
        public List<QuestionDetailDto> Questions { get; set; } = new();
        public List<int> RootQuestionIds { get; set; } = new(); // Th�m danh s�ch id c�c c�u g?c
    }

    public class QuestionDetailDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Order { get; set; }
        public bool IsRequired { get; set; }
        public QuestionTypeDto QuestionType { get; set; } = null!;
        public List<OptionBranchDto> Options { get; set; } = new();
        public List<QuestionBranchDto> Branches { get; set; } = new();
        public bool IsRoot { get; set; } // Th�m thu?c t�nh n�y
        public int? ParentQuestionId { get; set; } // Th�m parent question id
        public int? ParentOptionId { get; set; }   // Th�m parent option id
    }

    public class OptionBranchDto : OptionDto
    {
        public int? NextQuestionId { get; set; }
    }
}
