using DiaryApp.Models;
using DiaryApp.Repositories;

namespace DiaryApp.Views;

public partial class ShowEntriesPage : ContentPage
{
	public ShowEntriesPage()
	{
		InitializeComponent();
	}
	public void OnNewButtonClicked(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		//App.PersonRepo.AddNewPerson(newPerson.Text);
		//statusMessage.Text = App.PersonRepo.StatusMessage;
	}

	public async void OnGetButtonClicked(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		List<DayBehavior> dayBehaviors = await App.DayBehaviorRepo.GetAllDayBehaviors();
		dayBehaviors.Sort();
		dayBehaviorList.ItemsSource = dayBehaviors;
		statusMessage.Text = App.DayBehaviorRepo.StatusMessage;
	}

	private async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		Button button = sender as Button ;
		var d = button.BindingContext as DayBehavior;
		await App.DayBehaviorRepo.DeleteDayBehavior(d);

		List<DayBehavior> dayBehaviors = await App.DayBehaviorRepo.GetAllDayBehaviors();
		dayBehaviors.Sort();
		dayBehaviorList.ItemsSource = dayBehaviors;
		statusMessage.Text = App.DayBehaviorRepo.StatusMessage;

	}
}