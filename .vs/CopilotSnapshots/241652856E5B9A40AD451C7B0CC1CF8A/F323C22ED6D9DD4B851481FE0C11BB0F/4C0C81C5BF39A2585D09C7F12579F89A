using api.DTOs.User;
using api.Interfaces.IRepositories;
using api.Interfaces.IServices;
using api.Repositories;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<PagedResult<UserDto>> GetAllUserAsync(int page, int pageSize, string? search = null, string? role = null, int? departmentId = null, bool? isActive = null)
            => _repo.GetAllUserAsync(page, pageSize, search, role, departmentId, isActive);
        public Task<UserDto> CreateUserAsync(CreateUserDto dto) => _repo.CreateUserAsync(dto);
        public Task<UserDto> UpdateUserAsync(string id, UpdateUserDto dto) => _repo.UpdateUserAsync(id, dto);
        public Task<bool> DeleteUserAsync(string id) => _repo.DeleteUserAsync(id);
        public Task<UserDto> SetUserActiveStatusAsync(string id, bool isActive) => _repo.SetUserActiveStatusAsync(id, isActive);
        public Task<int> BulkDeleteUsersAsync(BulkUserActionRequest request) => _repo.BulkDeleteUsersAsync(request);
        public Task<int> BulkSetActiveStatusAsync(BulkSetActiveRequest request) => _repo.BulkSetActiveStatusAsync(request);
    }
}
