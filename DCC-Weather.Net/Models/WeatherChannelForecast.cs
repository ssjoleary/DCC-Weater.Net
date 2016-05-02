using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DCC_Weather.Models
{
    [DataContract]
    public class WeatherChannelForecast
    {
        [DataMember(Name = "forecast")]
        public Forecast Forecast { get; set; }
        
    }

    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "simpleforecast")]
        public SimpleForecast SimpleForecast { get; set; }
    }

    [DataContract]
    public class SimpleForecast
    {
        [DataMember(Name = "forecastday")]
        public List<ForecastDay> ForecastDays { get; set; }
    }

    [DataContract]
    public class ForecastDay
    {
        [DataMember(Name = "date")]
        public Date Date { get; set; }

        [DataMember(Name = "high")]
        public High High { get; set; }

        [DataMember(Name = "low")]
        public Low Low { get; set; }

        [DataMember(Name = "conditions")]
        public string Conditions { get; set; }

        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }
    }

    [DataContract]
    public class Date
    {
        [DataMember(Name = "epoch")]
        public long Epoch { get; set; }

        [DataMember(Name = "day")]
        public int Day { get; set; }

        [DataMember(Name = "month")]
        public int Month { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }
    }

    [DataContract]
    public class High
    {
        [DataMember(Name ="celsius")]
        public int Celsius { get; set; }
    }

    [DataContract]
    public class Low
    {
        [DataMember(Name = "celsius")]
        public int Celsius { get; set; }
    }
}