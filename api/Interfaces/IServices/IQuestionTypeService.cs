using api.DTOs.QuestionType;

namespace api.Interfaces.IServices
{
    public interface IQuestionTypeService
    {
        Task<IEnumerable<QuestionTypeDto>> GetAllAsync();
        Task<QuestionTypeDto?> GetByIdAsync(int id);
        Task<QuestionTypeDto> CreateAsync(CreateQuestionTypeDto dto);
        Task<QuestionTypeDto?> UpdateAsync(int id, UpdateQuestionTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
