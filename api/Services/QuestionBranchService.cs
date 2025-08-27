using api.DTOs.QuestionBranch;
using api.Interfaces.IRepositories;
using api.Interfaces.IServices;

namespace api.Services
{
    public class QuestionBranchService : IQuestionBranchService
    {
        private readonly IQuestionBranchRepository _repo;
        public QuestionBranchService(IQuestionBranchRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<QuestionBranchDto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<QuestionBranchDto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<QuestionBranchDto> CreateAsync(CreateQuestionBranchDto dto) => _repo.CreateAsync(dto);
        public Task<QuestionBranchDto?> UpdateAsync(int id, UpdateQuestionBranchDto dto) => _repo.UpdateAsync(id, dto);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
