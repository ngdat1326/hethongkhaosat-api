using api.DTOs.QuestionBranch;

namespace api.Interfaces.IRepositories
{
    public interface IQuestionBranchRepository
    {
        Task<IEnumerable<QuestionBranchDto>> GetAllAsync();
        Task<QuestionBranchDto?> GetByIdAsync(int id);
        Task<QuestionBranchDto> CreateAsync(CreateQuestionBranchDto dto);
        Task<QuestionBranchDto?> UpdateAsync(int id, UpdateQuestionBranchDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
