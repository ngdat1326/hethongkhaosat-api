using api.DTOs.Department;
using api.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageDepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public ManageDepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize] // Cho phép c? user và admin xem danh sách phòng ban
        public async Task<IActionResult> GetAll()
        {
            var departments = await _service.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        [Authorize] // Cho phép c? user và admin xem chi ti?t phòng ban
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _service.GetByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            var department = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentDto dto)
        {
            var department = await _service.UpdateAsync(id, dto);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}