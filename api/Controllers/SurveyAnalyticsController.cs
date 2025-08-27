using api.Data;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SurveyAnalyticsController : ControllerBase
    {
        private readonly SurveyAnalyticsService _service;
        public SurveyAnalyticsController(ApplicationDbContext context)
        {
            _service = new SurveyAnalyticsService(context);
        }

        [HttpGet("{surveyId}")]
        public IActionResult GetSurveyAnalytics(int surveyId)
        {
            var result = _service.GetSurveyAnalytics(surveyId);
            return Ok(result);
        }
    }
}
