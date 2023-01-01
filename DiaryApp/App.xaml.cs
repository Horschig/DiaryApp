using DiaryApp.Repositories;

namespace DiaryApp;

public partial class App : Application
{
	public static DayBehaviorRepository DayBehaviorRepo { get; private set; }

	public App(DayBehaviorRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		DayBehaviorRepo = repo;
	}
}
