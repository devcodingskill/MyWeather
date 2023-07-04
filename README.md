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

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)