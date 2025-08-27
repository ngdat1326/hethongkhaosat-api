using api.DTOs.Option;
using api.Interfaces.IRepositories;
using api.Interfaces.IServices;

namespace api.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repo;
        public OptionService(IOptionRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<OptionDto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<OptionDto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<OptionDto> CreateAsync(CreateOptionDto dto) => _repo.CreateAsync(dto);
        public Task<OptionDto?> UpdateAsync(int id, UpdateOptionDto dto) => _repo.UpdateAsync(id, dto);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
        // Thêm hàm thay th? toàn b? options cho m?t câu h?i
        public Task<bool> ReplaceOptionsForQuestionAsync(int questionId, List<CreateOptionDto> newOptions)
            => _repo.ReplaceOptionsForQuestionAsync(questionId, newOptions);
    }
}
