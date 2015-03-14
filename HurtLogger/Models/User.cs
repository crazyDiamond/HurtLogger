using SQLite.Net.Attributes;
using System;

namespace HurtLogger
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }
		public string Sex{ get; set;}
		public int Age { get; set; }

		private DateTime _lastUpdatedAt;
		public DateTime LastUpdatedAt {
			get{ return Helper.ConvertToLocalTime(_lastUpdatedAt); }
			set{ _lastUpdatedAt = value;}
			
		}
		public bool IsAdmin { get; set;}
	}



}

