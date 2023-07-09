# MyWeather

MyWeather is using .NET Maui for crossing platform 

## Golas
- Use Maui shell for navigation and dependency injection
- MVVM(S) for data binding
- Learn how binding data and format string on xaml file
- Http call
- Create converter and how to use it  
## Sample image for the project

<p align="center">
  <img src="(https://github.com/devcodingskill/MyWeather/blob/master/SampleImage/Screenshot_1.png)" width="350" title="hover text">  
</p>

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

### Register file in MauiProgram 
- More detail about .NET dependency injection https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
```c
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//register 
		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddSingleton<DashboardViewModel>();
		builder.Services.AddSingleton<WeatherService>();

		return builder.Build();
	}
}

```
### Connect DashboardPage to DashbordViewModel
- Inject viewModel to DashboardPage by ask the container to give DashboardView model to class constructer and set binding to the page
```c
public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
```
- Set up binding on xaml page and Set data type so it able to user intellisense on xaml file
```c
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm ="clr-namespace:MyWeather.ViewModels"
             x:Class="MyWeather.View.DashboardPage"
             x:DataType="vm:DashboardViewModel"
             Shell.NavBarIsVisible="False"
             Title="{Binding Title}">
```
- Binding data to page by binding from viewModel
```c
 <Label FontSize="16"
                   Text="{Binding Data.name}"
                   TextColor="White"
                   VerticalOptions="Center" />
```
- String format in xaml 
```c
 //set number of decimal point
 Text="{Binding Data.main.temp , StringFormat='{0:F0}'}"

 //set date time in month and year
 Text="{Binding Data.dt, Converter={StaticResource LongToDateConverter} ,StringFormat='{0:M}, {0:yyyy}'}"

 //set time
 Text="{Binding Data.sys.sunrise, Converter={StaticResource LongToDateConverter} ,StringFormat='{0:HH}:{0:mm}:{0:ss}'}" 

 //set string format 
 Text="{Binding Data.clouds.all, StringFormat='{0} %'}" />
```
### Add converter using IValueConverter
- Add converter file  
```c
 public class LongToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int ticks)
            {
                return new DateTime(ticks);
            }
            if (value is long tick)
            {
               return new DateTime(tick);
            }
            // Fallback value, could also be something else
            return DateTime.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
```
- use converter on xaml file
```c
 <ContentPage.Resources>
        <ResourceDictionary>
            <converter:LongToDateTimeConverter x:Key="LongToDateConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>

//calling converter
 Text="{Binding Data.dt, Converter={StaticResource LongToDateConverter} ,StringFormat='{0:M}, {0:yyyy}'}"
```
## Link use in this project
- Get API key => https://openweathermap.org/api
- Convert json to c# => https://json2csharp.com/
- time convert => https://www.datetimetoticks-converter.com/
- video for the project => https://www.youtube.com/watch?v=uDaIArfc5LM

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
