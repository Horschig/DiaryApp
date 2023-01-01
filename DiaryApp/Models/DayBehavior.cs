using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DiaryApp.Models
{
	[Table("daybehavior")]
	public class DayBehavior : IComparable<DayBehavior>
	{
		[PrimaryKey, AutoIncrement] 
		public int Id { get; set; }

		public DateTime EntryDateTime { get; set; }

		public string BehaviourCharacteristics { get; set; }

		public string FallAsleepTime{ get; set; }

		public string WakeupTime { get; set; }

		public int CompareTo(DayBehavior d)
		{
			if (d == null)
			{
				return 1;
			}

			return DateTime.Compare(this.EntryDateTime, d.EntryDateTime);
		}
	}
}
