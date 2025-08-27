using api.Data;
using api.DTOs.QuestionBranch;
using api.Interfaces.IRepositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class QuestionBranchRepository : IQuestionBranchRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionBranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuestionBranchDto>> GetAllAsync()
        {
            return await _context.QuestionBranches
                .Include(qb => qb.BranchOptions)
                .Select(qb => new QuestionBranchDto
                {
                    Id = qb.Id,
                    CurrentQuestionId = qb.CurrentQuestionId,
                    NextQuestionId = qb.NextQuestionId,
                    ConditionType = qb.ConditionType,
                    OptionIds = qb.BranchOptions.Select(bo => bo.OptionId).ToList()
                }).ToListAsync();
        }
        public async Task<QuestionBranchDto?> GetByIdAsync(int id)
        {
            var qb = await _context.QuestionBranches
                .Include(qb => qb.BranchOptions)
                .FirstOrDefaultAsync(qb => qb.Id == id);
            if (qb == null) return null;
            return new QuestionBranchDto
            {
                Id = qb.Id,
                CurrentQuestionId = qb.CurrentQuestionId,
                NextQuestionId = qb.NextQuestionId,
                ConditionType = qb.ConditionType,
                OptionIds = qb.BranchOptions.Select(bo => bo.OptionId).ToList()
            };
        }
        public async Task<QuestionBranchDto> CreateAsync(CreateQuestionBranchDto dto)
        {
            // L?y thông tin câu h?i g?c
            var currentQuestion = await _context.Questions.FindAsync(dto.CurrentQuestionId);
            if (currentQuestion == null)
                throw new InvalidOperationException("Câu h?i g?c không t?n t?i.");
            // L?y id lo?i text ??ng theo Code
            var textType = await _context.QuestionTypes.FirstOrDefaultAsync(t => t.Code == "Text");
            if (textType != null && currentQuestion.QuestionTypeId == textType.Id)
                throw new InvalidOperationException("Không th? t?o nhánh cho câu h?i d?ng text.");

            bool isGeneral = dto.OptionIds == null || dto.OptionIds.Count == 0;
            // L?y các branch cùng t? h?p
            var sameBranches = await _context.QuestionBranches
                .Include(qb => qb.BranchOptions)
                .Where(qb => qb.CurrentQuestionId == dto.CurrentQuestionId
                          && qb.NextQuestionId == dto.NextQuestionId
                          && qb.ConditionType == dto.ConditionType)
                .ToListAsync();

            if (isGeneral)
            {
                // N?u ?ã có branch c? th? thì không cho phép l?u branch t?ng quát
                if (sameBranches.Any(b => b.BranchOptions.Any()))
                    throw new InvalidOperationException("?ã t?n t?i branch c? th? cho t? h?p này, không th? thêm branch t?ng quát.");
            }
            else
            {
                // N?u ?ã có branch t?ng quát thì xóa branch t?ng quát tr??c khi l?u branch c? th?
                var generalBranch = sameBranches.FirstOrDefault(b => !b.BranchOptions.Any());
                if (generalBranch != null)
                {
                    _context.QuestionBranchOptions.RemoveRange(generalBranch.BranchOptions);
                    _context.QuestionBranches.Remove(generalBranch);
                    await _context.SaveChangesAsync();
                }
            }

            var qb = new QuestionBranch
            {
                CurrentQuestionId = dto.CurrentQuestionId,
                NextQuestionId = dto.NextQuestionId,
                ConditionType = dto.ConditionType
            };
            _context.QuestionBranches.Add(qb);
            await _context.SaveChangesAsync();
            // Add branch options
            foreach (var optionId in dto.OptionIds)
            {
                _context.QuestionBranchOptions.Add(new QuestionBranchOption
                {
                    QuestionBranchId = qb.Id,
                    OptionId = optionId
                });
            }
            await _context.SaveChangesAsync();
            return new QuestionBranchDto
            {
                Id = qb.Id,
                CurrentQuestionId = qb.CurrentQuestionId,
                NextQuestionId = qb.NextQuestionId,
                ConditionType = qb.ConditionType,
                OptionIds = dto.OptionIds
            };
        }
        public async Task<QuestionBranchDto?> UpdateAsync(int id, UpdateQuestionBranchDto dto)
        {
            var qb = await _context.QuestionBranches
                .Include(qb => qb.BranchOptions)
                .FirstOrDefaultAsync(qb => qb.Id == id);
            if (qb == null) return null;
            qb.CurrentQuestionId = dto.CurrentQuestionId ?? qb.CurrentQuestionId;
            qb.NextQuestionId = dto.NextQuestionId ?? qb.NextQuestionId;
            qb.ConditionType = dto.ConditionType ?? qb.ConditionType;
            if (dto.OptionIds != null)
            {
                // Remove old options
                _context.QuestionBranchOptions.RemoveRange(qb.BranchOptions);
                // Add new options
                foreach (var optionId in dto.OptionIds)
                {
                    _context.QuestionBranchOptions.Add(new QuestionBranchOption
                    {
                        QuestionBranchId = qb.Id,
                        OptionId = optionId
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new QuestionBranchDto
            {
                Id = qb.Id,
                CurrentQuestionId = qb.CurrentQuestionId,
                NextQuestionId = qb.NextQuestionId,
                ConditionType = qb.ConditionType,
                OptionIds = dto.OptionIds ?? qb.BranchOptions.Select(bo => bo.OptionId).ToList()
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var qb = await _context.QuestionBranches
                .Include(qb => qb.BranchOptions)
                .FirstOrDefaultAsync(qb => qb.Id == id);
            if (qb == null) return false;
            _context.QuestionBranchOptions.RemoveRange(qb.BranchOptions);
            _context.QuestionBranches.Remove(qb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
