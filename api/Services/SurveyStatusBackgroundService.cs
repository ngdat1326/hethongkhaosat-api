using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using api.Interfaces.IServices;

namespace api.Services
{
    public class SurveyStatusBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(5);

        public SurveyStatusBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var surveyService = scope.ServiceProvider.GetRequiredService<ISurveyService>();
                    await surveyService.UpdateExpiredSurveysStatusAsync(2);
                    await Task.Delay(_interval, stoppingToken);
                }
            }
        }
    }
}
