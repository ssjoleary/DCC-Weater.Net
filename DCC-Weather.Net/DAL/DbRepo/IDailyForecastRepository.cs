using DCC_Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC_Weather.DAL.DbRepo
{
    public interface IDailyForecastRepository
    {
        bool Update3DayForecast(List<DailyForecast> dailyForecasts);
        List<DailyForecast> Get3DayForecastWithDiff();
    }
}
