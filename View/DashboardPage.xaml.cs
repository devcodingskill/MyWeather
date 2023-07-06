using MyWeather.Models;
using MyWeather.ViewModels;

namespace MyWeather.View;

public partial class DashboardPage : ContentPage
{
	
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}