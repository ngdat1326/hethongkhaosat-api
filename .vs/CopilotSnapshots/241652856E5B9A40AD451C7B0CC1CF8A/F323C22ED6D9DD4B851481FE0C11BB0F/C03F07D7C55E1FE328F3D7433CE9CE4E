using api.DTOs.User;

namespace api.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<PagedResult<UserDto>> GetAllUserAsync(int page, int pageSize, string? search = null, string? role = null, int? departmentId = null, bool? isActive = null);
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        Task<UserDto> UpdateUserAsync(string id, UpdateUserDto dto);
        Task<bool> DeleteUserAsync(string id);
        Task<UserDto> SetUserActiveStatusAsync(string id, bool isActive);
        Task<int> BulkDeleteUsersAsync(BulkUserActionRequest request);
        Task<int> BulkSetActiveStatusAsync(BulkSetActiveRequest request);
    }
}
