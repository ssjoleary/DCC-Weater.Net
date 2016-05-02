using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DCC_Weather.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Runtime.Serialization.Json;

namespace DCC_Weather.DAL
{
    public class WeatherChannelApi : IExternalApi
    {
        private string apiKey = "8559dda6fb73dc2c";
        
        public async Task<List<DailyForecast>> get3DayForecast()
        {
            try
            {
                string threeDayForecastRequest = CreateRequest("UK/London");
                WeatherChannelForecast threeDayForecastResponse = await MakeRequest(threeDayForecastRequest);
                List<DailyForecast> dailyForecasts = ProcessResponse(threeDayForecastResponse);
                return dailyForecasts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }               

        public string CreateRequest(string queryString)
        {
            string urlRequest = "https://api.wunderground.com/api/" + apiKey + "/forecast/q/" + queryString + ".json";
            return urlRequest;
        }

        private async Task<WeatherChannelForecast> MakeRequest(string threeDayForecastRequestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(threeDayForecastRequestUrl) as HttpWebRequest;
                using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(string.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WeatherChannelForecast));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    WeatherChannelForecast jsonResponse = objResponse as WeatherChannelForecast;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private List<DailyForecast> ProcessResponse(WeatherChannelForecast threeDayForecastResponse)
        {
            List<DailyForecast> dailyForecasts = new List<DailyForecast>();
            threeDayForecastResponse.Forecast.SimpleForecast.ForecastDays.ForEach(forecast => dailyForecasts.Add(
                new DailyForecast
                {
                    Conditions = forecast.Conditions,
                    ForecastDate = new DateTime(forecast.Date.Year, forecast.Date.Month, forecast.Date.Day),
                    High = forecast.High.Celsius,
                    Low = forecast.Low.Celsius,
                    IconUrl = forecast.IconUrl
                }));

            return dailyForecasts.OrderBy(x => x.ForecastDate).ToList();
        }
    }
}