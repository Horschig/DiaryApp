using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApp.Models;

namespace DiaryApp.Repositories
{
	public class DayBehaviorRepository
	{
		string _dbPath;

		public string StatusMessage { get; set; }

		private SQLiteAsyncConnection conn;

		private async Task Init()
		{
			if (conn != null)
				return;

			conn = new SQLiteAsyncConnection(_dbPath);

			// create table if it does not exist yet
			await conn.CreateTableAsync<DayBehavior>();
		}


		public DayBehaviorRepository(string dbPath)
		{
			_dbPath = dbPath;
		}

		public async Task AddNewDayBehavior(string characteristics, string fallasleeptime, string wakeuptime, DateTime datetime)
		{
			int result = 0;
			try
			{
				await Init();

				// basic validation 
				if (string.IsNullOrEmpty(characteristics))
					throw new Exception("Valid characteristics required");

				if (string.IsNullOrEmpty(fallasleeptime))
					throw new Exception("Valid fallasleeptime required");

				if (string.IsNullOrEmpty(wakeuptime))
					throw new Exception("Valid wakeuptime required");

				result = await conn.InsertAsync(new DayBehavior{ BehaviourCharacteristics= characteristics, FallAsleepTime = fallasleeptime, WakeupTime = wakeuptime, EntryDateTime = datetime }); ;

				StatusMessage = string.Format("{0} record(s) added (BehaviourCharacteristics: {1})", result, characteristics);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add. Error: {0}", ex.Message);
			}
		}


		public async Task DeleteDayBehavior(DayBehavior d)
		{
			int result = 0;

			try
			{
				await Init();

				// basic validation to ensure a name was entered
				if (d == null)
					throw new Exception("DayBehavior to be deleted cannot be null.");

				result = await conn.DeleteAsync(d);
				StatusMessage = string.Format("{0} record(s) deleted (ID: {1}, Entry DateTime: {2})", result, d.Id, d.EntryDateTime);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to delete (ID: {0}, Entry DateTime: {1}). Error:{2}", result, d.Id, d.EntryDateTime, ex.Message);
			}


		}

		public async Task<List<DayBehavior>> GetAllDayBehaviors()
		{
			// TODO: Init then retrieve a list of Player objects from the database into a list
			try
			{
				await Init();
				return await conn.Table<DayBehavior>().ToListAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
			}

			return new List<DayBehavior>();
		}
	}
}
