using SQLite.Net.Attributes;

namespace HurtLogger
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }
		public string Sex{ get; set;}
		public int Age { get; set; }
		public bool IsAdmin { get; set;}
	}



}

