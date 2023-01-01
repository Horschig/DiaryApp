using DiaryApp.Repositories;

namespace DiaryApp;

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

		string dbPath = FileAccessHelper.GetLocalFilePath("daybehavior.db3");
		builder.Services.AddSingleton<DayBehaviorRepository>(s => ActivatorUtilities.CreateInstance<DayBehaviorRepository>(s, dbPath));

		return builder.Build();
	}

}
