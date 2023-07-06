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
        public async Task<Root> GetWeatheData() 
        {
            Root data = null;
            var url = "https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=bedbe4b73cd70a2a5c8cbaa28d7d8b57";
            data = await RemoteDataService.Instance.HttpGet<Root>(url);
            if (data == null)
                return null;
           
            return data;
        
        }
    }
}
