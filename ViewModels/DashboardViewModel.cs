using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWeather.Models;
using MyWeather.Services;

namespace MyWeather.ViewModels
{
    public partial class DashboardViewModel : BaseViewModel
    {
        WeatherService weatherService;
       
        [ObservableProperty]
        private Root data;
        public DashboardViewModel(WeatherService weatherService)
        {
            this.weatherService = weatherService;
            Title = "Test";
            GetHardCodeData();
        }
        [RelayCommand]
        async Task GetData() 
        {
            if (Data != null)
                Data = null;

           Data = await weatherService.GetWeatheData();
        }
        void GetHardCodeData() 
        {
            Data = new Root()
            {
                coord = new Coord()
                { lon = -0.1257,
                    lat = 51.5085
                },
                weather_from = new Weather() 
                {

                    id = 802,
                    main = "Clouds",
                    description = "scattered clouds",
                    icon = "03d"

                },
                weather = new List<Weather>()
                {
                    new Weather()
                    {
                        id = 802,
                        main = "Clouds",
                        description = "scattered clouds",
                        icon = "03d"
                    },
                    new Weather()
                    {
                        id = 803,
                        main = "Clouds",
                        description = "scattered clouds",
                        icon = "03d"
                    },
                },
                @base  = "stations",
                main =new Main() 
                {
                    temp = UnitConverters.FahrenheitToCelsius(67.31),
                    feels_like = UnitConverters.FahrenheitToCelsius(60.31),
                    temp_max = 0,
                    pressure = 1011,
                    humidity = 72,
                },
                visibility = 10000,
                wind = new Wind() { 
                speed = 5.66,
                deg = 270,
                },
                clouds = new Clouds() { 
                all =   40
                },
                dt = 638232480000000000,
                sys= new Sys()
                {
                    type = 2,
                    id = 2075535,
                    country="GB",
                    sunrise = 638232480000000000,
                    sunset = 638233343990000000,
                },
                timezone = 3600,
                id = 2643743,
                name = "London",
                cod = 200
            };
        }
    }
}
