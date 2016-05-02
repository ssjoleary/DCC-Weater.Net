using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DCC_Weather.Models;
using System.Data;

namespace DCC_Weather.DAL.DbRepo
{
    public class DailyForecastLocalDb : IDailyForecastRepository
    {
        public List<DailyForecast> Get3DayForecastWithDiff()
        {
            WeatherContext db = new WeatherContext();
            DateTime currentDayMinus1 = DateTime.Now.AddDays(-1);

            return db.DailyForecasts.Where(forecast => forecast.ForecastDate.Value >= currentDayMinus1).ToList();
        }

        public bool Update3DayForecast(List<DailyForecast> dailyForecasts)
        {
            WeatherContext db = new WeatherContext();
            try
            {
                var avgHigh = db.DailyForecasts.Where(x => x.ForecastDate < DateTime.Now).Average(x => x.High);
                var avgLow = db.DailyForecasts.Where(x => x.ForecastDate < DateTime.Now).Average(x => x.Low);

                foreach (DailyForecast dailyFC in dailyForecasts)
                {
                    dailyFC.HighDiff = dailyFC.High - (int)Math.Round(avgHigh);
                    dailyFC.LowDiff = dailyFC.Low - (int)Math.Round(avgLow);

                    var original = db.DailyForecasts.Find(dailyFC.ForecastDate);
                    if (original != null)
                    {
                        db.Entry(original).CurrentValues.SetValues(dailyFC);
                    }
                    else
                    {
                        db.DailyForecasts.Add(dailyFC);
                    }
                }                

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }        
    }
}