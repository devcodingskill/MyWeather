using MyWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeather.Services
{
    public class WeatherService
    {
        public WeatherService()
        {
              
        }
        public async Task<Root> GetWeatheData(string location) 
        {
            Root data = null;
           
            data = await RemoteDataService.Instance.HttpGet<Root>(SetupRequest(location));
            if (data == null)
                return null;
           
            return data;
        
        }
        private string SetupRequest(string location) 
        {
            string requestUrl = string.Empty;

            if (!string.IsNullOrEmpty(location))
            {
                requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={location}&APPID=bedbe4b73cd70a2a5c8cbaa28d7d8b57";
            }
            else 
            {
                requestUrl = "https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=bedbe4b73cd70a2a5c8cbaa28d7d8b57";
            }
            return requestUrl;
        }
    }
}
