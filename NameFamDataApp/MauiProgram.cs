using CommunityToolkit.Maui;
using NameFamDataApp.ViewModel;

namespace NameFamDataApp;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		return builder.Build();
	}
}
