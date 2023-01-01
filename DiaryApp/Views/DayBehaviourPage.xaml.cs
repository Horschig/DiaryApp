using System.Windows.Input;

namespace DiaryApp.Views;

public partial class DayBehaviourPage : ContentPage
{

	public DayBehaviourPage()
	{
		InitializeComponent();
	}

	private void OnEntryCompleted(object sender, EventArgs e)
	{

	}
	private async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		await App.DayBehaviorRepo.AddNewDayBehavior(dayCharacteristicsEntry.Text, fallAsleepTimeEntry.Text, wakeupTimeEntry.Text, datePicker.Date);
		statusMessageLabel.Text = App.DayBehaviorRepo.StatusMessage;
	}


}