using api.Data;
using api.Interfaces.IRepositories;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly ApplicationDbContext _context;
        public ResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> AddResponseAsync(Response response)
        {
            _context.Responses.Add(response);
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<List<Response>> GetResponsesBySurveyIdAsync(int surveyId)
        {
            return await _context.Responses
                .Include(r => r.Answers)
                .Where(r => r.SurveyId == surveyId)
                .ToListAsync();
        }
    }

    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAnswersAsync(IEnumerable<Answer> answers)
        {
            foreach (var answer in answers)
            {
                answer.QuestionIdBackup = answer.QuestionId;
                answer.OptionIdBackup = answer.OptionId;
                answer.ExtraOptionIdsBackup = answer.ExtraOptionIds;
            }
            _context.Answers.AddRange(answers);
            await _context.SaveChangesAsync();
        }
    }
}
