using api.DTOs.QuestionType;

namespace api.Interfaces.IRepositories
{
    public interface IQuestionTypeRepository
    {
        Task<IEnumerable<QuestionTypeDto>> GetAllAsync();
        Task<QuestionTypeDto?> GetByIdAsync(int id);
        Task<QuestionTypeDto> CreateAsync(CreateQuestionTypeDto dto);
        Task<QuestionTypeDto?> UpdateAsync(int id, UpdateQuestionTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
