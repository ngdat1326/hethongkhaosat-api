using api.DTOs.Survey;
using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces.IRepositories
{
    public interface IResponseRepository
    {
        Task<Response> AddResponseAsync(Response response);
        Task<List<Response>> GetResponsesBySurveyIdAsync(int surveyId);
    }

    public interface IAnswerRepository
    {
        Task AddAnswersAsync(IEnumerable<Answer> answers);
    }
}
