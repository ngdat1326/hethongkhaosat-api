using api.Data;
using api.DTOs.Department;
using api.Interfaces.IRepositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDto { Id = d.Id, Name = d.Name, Code = d.Code })
                .ToListAsync();
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return null;
            return new DepartmentDto { Id = d.Id, Name = d.Name, Code = d.Code };
        }

        public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
        {
            var d = new Department { Name = dto.Name, Code = dto.Code };
            _context.Departments.Add(d);
            await _context.SaveChangesAsync();
            return new DepartmentDto { Id = d.Id, Name = d.Name, Code = d.Code };
        }

        public async Task<DepartmentDto?> UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return null;
            d.Name = dto.Name ?? d.Name;
            d.Code = dto.Code ?? d.Code;
            await _context.SaveChangesAsync();
            return new DepartmentDto { Id = d.Id, Name = d.Name, Code = d.Code };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var d = await _context.Departments.FindAsync(id);
            if (d == null) return false;
            _context.Departments.Remove(d);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}