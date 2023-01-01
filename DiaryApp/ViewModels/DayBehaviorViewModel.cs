using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiaryApp.ViewModels
{
	public class DayBehaviorViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<DayBehavior> DayBehaviors{ get; private set; }

		public ICommand SaveDayBehaviorEntryCommand => new Command(async () => await SaveDayBehaviorEntryAsync());

		public DayBehaviorViewModel()
		{
			Task.Run(() => this.GetAllEntries());

			if (DayBehaviors == null)
				return;
		}
		async void GetAllEntries()
		{
			DayBehaviors = new ObservableCollection<DayBehavior>(await App.DayBehaviorRepo.GetAllDayBehaviors());
		}

		public async Task SaveDayBehaviorEntryAsync()
		{
			await Application.Current.MainPage.DisplayAlert("Result", "You lost 0-6", "OK");
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
