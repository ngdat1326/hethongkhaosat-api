using api.DTOs.Option;

namespace api.Interfaces.IRepositories
{
    public interface IOptionRepository
    {
        Task<IEnumerable<OptionDto>> GetAllAsync();
        Task<OptionDto?> GetByIdAsync(int id);
        Task<OptionDto> CreateAsync(CreateOptionDto dto);
        Task<OptionDto?> UpdateAsync(int id, UpdateOptionDto dto);
        Task<bool> DeleteAsync(int id);
        // Th�m h�m thay th? to�n b? options cho m?t c�u h?i
        Task<bool> ReplaceOptionsForQuestionAsync(int questionId, List<CreateOptionDto> newOptions);
    }
}
