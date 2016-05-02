using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DCC_Weather.Models
{
    public class DailyForecast
    {   
        [Key]
        public DateTime? ForecastDate { get; set; }
        public string Conditions { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public int? HighDiff { get; set; }
        public int? LowDiff { get; set; }
        public string IconUrl { get; set; }        
    }
}