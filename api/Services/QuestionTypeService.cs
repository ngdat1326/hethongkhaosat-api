using api.DTOs.QuestionType;
using api.Interfaces.IRepositories;
using api.Interfaces.IServices;

namespace api.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _repo;
        public QuestionTypeService(IQuestionTypeRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<QuestionTypeDto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<QuestionTypeDto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<QuestionTypeDto> CreateAsync(CreateQuestionTypeDto dto) => _repo.CreateAsync(dto);
        public Task<QuestionTypeDto?> UpdateAsync(int id, UpdateQuestionTypeDto dto) => _repo.UpdateAsync(id, dto);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
