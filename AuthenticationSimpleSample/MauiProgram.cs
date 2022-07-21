using AuthenticationSimpleSample.View;
using AuthenticationSimpleSample.ViewModel;

namespace AuthenticationSimpleSample;

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
				fonts.AddFont("SF-Pro.ttf", "MainFont");
				fonts.AddFont("SF-Pro-Italic.ttf", "MainFontTwo");
			});
		// AddTransient for new page instance for navigation
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<HomeScreen>();
		builder.Services.AddSingleton<SettingsPage>();

		builder.Services.AddSingleton<HomeScreenViewModel>();
		builder.Services.AddSingleton<SettingsPageViewModel>();

		return builder.Build();
	}
}
