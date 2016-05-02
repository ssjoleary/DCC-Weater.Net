using DCC_Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC_Weather.Services
{
    public interface IDailyForecastService
    {
        Task<List<DailyForecast>> Get3DayForecast();
    }
}
