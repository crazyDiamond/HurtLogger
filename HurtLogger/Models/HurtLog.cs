using SQLite.Net.Attributes;
using System;

namespace HurtLogger
{
	public class HurtLog 
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Title { get; set;}
		public int UserId { get; set;}
		public string  Category { get; set;} 
		public string Description { get; set; }
		public DateTime Date{ get; set;}
	}
}


