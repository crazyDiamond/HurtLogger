using SQLite.Net.Attributes;

namespace HurtLogger
{
	public class Category
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
	}
}

