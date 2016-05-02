using DCC_Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCC_Weather.DAL
{
    public interface IExternalApi
    {
        Task<List<DailyForecast>> get3DayForecast();
    }
}
