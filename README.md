# MyWeather

MyWeather is using .NET Maui for crossing platform

## Step 
### Create the necessary folder for the project using MVVM(S)
- Models
- Views
- ViewModels
- Services 

### Added DashboardPage in Views folder 
- Add xaml file to View floder
- Edit AppShell.xaml => xmlns:view="clr-namespace:MyWeather.View"

```c
                 <ShellContent Title="Dashboard"
                  ContentTemplate="{DataTemplate view:DashboardPage}"
                  Route="DashboardPage" />
```

### Added BaseViewModel in ViewModel folder 
- Add Nuget Package => CommunityToolkit.Mvvm
- Add BaseViewModel => make the class partial because of soure generator it will create to soure automaticaly 
- Inheritance form ObservableObject
- Add some property for the BaseViewModel
- Add attribute key word for code Generation

```c
public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;
        
        [ObservableProperty]
        private string title;
        public bool IsNotBusy => !IsBusy;
    }
```

### Added DashboardViewModel in ViewModel folder 
- Add DashboardViewModel which inheritance from BaseViewModel
- Add method and property 
- Add mock up data
```c
 Data = new Root()
            {
                coord = new Coord()
                { lon = -0.1257,
                    lat = 51.5085
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
                    temp = 291.31,
                    feels_like = 291.06,
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
                dt = 168857503,
                sys= new Sys()
                {
                    type = 2,
                    id = 2075535,
                    country="GB",
                    sunrise = 1688529012,
                    sunset = 1688588368,
                },
                timezone = 3600,
                id = 2643743,
                name = "London",
                cod = 200
            };
        }
    }
```

### Add service to service folder 
- RemoteDataService => default service that can user on other project (Http call)
- loggerService => default service that can user on other project (error log)
- WeatherService




## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)