using DCC_Weather.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DCC_Weather.DAL.DbRepo
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherContext")
        {
        }

        public DbSet<DailyForecast> DailyForecasts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}