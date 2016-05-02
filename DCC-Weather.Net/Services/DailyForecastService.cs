using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DCC_Weather.Models;
using DCC_Weather.DAL;
using DCC_Weather.DAL.DbRepo;

namespace DCC_Weather.Services
{
    public class DailyForecastService : IDailyForecastService
    {
        private readonly IExternalApi _externalApi;
        private readonly IDailyForecastRepository _dailyForecastRepository;

        public DailyForecastService(IExternalApi externalApi, IDailyForecastRepository dailyForecastRepository)
        {
            _externalApi = externalApi;
            _dailyForecastRepository = dailyForecastRepository;
        }

        public async Task<List<DailyForecast>> Get3DayForecast()
        {
            _dailyForecastRepository.Update3DayForecast(await _externalApi.get3DayForecast());
            return _dailyForecastRepository.Get3DayForecastWithDiff();
        }
    }
}