using DCC_Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCC_Weather.DAL.DbRepo
{
    public class WeatherInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            var dailyForecasts = new List<DailyForecast>();
            var rand = new Random();
            for (int i = 0; i <= 28; i++)
            {
                context.DailyForecasts.Add(new DailyForecast { ForecastDate = new DateTime(1970, 1, i + 1), High = rand.Next(15, 26), Low = rand.Next(5, 16) });                
            }

            context.SaveChanges();
        }
    }
}