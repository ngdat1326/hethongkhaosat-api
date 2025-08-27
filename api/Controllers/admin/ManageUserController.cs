using api.DTOs;
using api.DTOs.User;
using api.Interfaces.IServices;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly UserManager<AppUser> _userManager;

        public ManageUserController(IUserService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("list-user")]
        [Authorize] // Cho phép cả user và admin xem danh sách user
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] string? role = null,
            [FromQuery] int? departmentId = null,
            [FromQuery] bool? isActive = null)
        {
            var users = await _service.GetAllUserAsync(page, pageSize, search, role, departmentId, isActive);
            return Ok(users);
        }

        [HttpPost("create-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var user = await _service.CreateUserAsync(dto);
            return Ok(user);
        }

        [HttpPut("update-user/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto dto)
        {
            var updated = await _service.UpdateUserAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("delete-user/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var deleted = await _service.DeleteUserAsync(id);
            if (!deleted) return NotFound("Không tìm thấy user.");
            return NoContent();
        }

        [HttpPut("set-active/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetActiveStatus(string id, [FromQuery] bool isActive)
        {
            var user = await _service.SetUserActiveStatusAsync(id, isActive);
            return Ok(user);
        }

        [HttpPost("bulk-delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BulkDelete([FromBody] BulkUserActionRequest request)
        {
            var count = await _service.BulkDeleteUsersAsync(request);
            return Ok(new { deleted = count });
        }

        [HttpPost("bulk-set-active")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BulkSetActive([FromBody] BulkSetActiveRequest request)
        {
            var count = await _service.BulkSetActiveStatusAsync(request);
            return Ok(new { updated = count });
        }

        [HttpPost("reset-password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return NotFound("Không tìm thấy user.");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, "Matkhau@123456789");
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(new { message = "Đặt lại mật khẩu thành công." });
        }
    }
}
