using api.Data;
using api.DTOs.QuestionType;
using api.Interfaces.IRepositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuestionTypeDto>> GetAllAsync()
        {
            return await _context.QuestionTypes.Select(qt => new QuestionTypeDto
            {
                Id = qt.Id,
                Code = qt.Code,
                Name = qt.Name,
                Description = qt.Description,
                IsActive = qt.IsActive
            }).ToListAsync();
        }
        public async Task<QuestionTypeDto?> GetByIdAsync(int id)
        {
            var qt = await _context.QuestionTypes.FindAsync(id);
            if (qt == null) return null;
            return new QuestionTypeDto
            {
                Id = qt.Id,
                Code = qt.Code,
                Name = qt.Name,
                Description = qt.Description,
                IsActive = qt.IsActive
            };
        }
        public async Task<QuestionTypeDto> CreateAsync(CreateQuestionTypeDto dto)
        {
            var qt = new QuestionType
            {
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive
            };
            _context.QuestionTypes.Add(qt);
            await _context.SaveChangesAsync();
            return new QuestionTypeDto
            {
                Id = qt.Id,
                Code = qt.Code,
                Name = qt.Name,
                Description = qt.Description,
                IsActive = qt.IsActive
            };
        }
        public async Task<QuestionTypeDto?> UpdateAsync(int id, UpdateQuestionTypeDto dto)
        {
            var qt = await _context.QuestionTypes.FindAsync(id);
            if (qt == null) return null;
            qt.Code = dto.Code ?? qt.Code;
            qt.Name = dto.Name ?? qt.Name;
            qt.Description = dto.Description ?? qt.Description;
            qt.IsActive = dto.IsActive ?? qt.IsActive;
            await _context.SaveChangesAsync();
            return new QuestionTypeDto
            {
                Id = qt.Id,
                Code = qt.Code,
                Name = qt.Name,
                Description = qt.Description,
                IsActive = qt.IsActive
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var qt = await _context.QuestionTypes.FindAsync(id);
            if (qt == null) return false;
            _context.QuestionTypes.Remove(qt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
