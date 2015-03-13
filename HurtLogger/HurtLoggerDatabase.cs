using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite.Net;
using System.Linq;

namespace HurtLogger
{
	public class DatabaseAccessor
	{
		SQLiteConnection database;
		public DatabaseAccessor ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<User>();
		}
		public IEnumerable<User> GetItems () {
			return (from i in database.Table<User>() select i).ToList();
		}
//		public IEnumerable<User> GetItemsNotDone ()
//		{
//			return database.Query<User>("SELECT * FROM [User] WHERE [Done] = 0");
//		}
		public User GetItem (int id) 
		{
			return database.Table<User>().FirstOrDefault(x => x.ID == id);
		}
		public int DeleteItem(int id)
		{
			return database.Delete<User>(id);
		}
	}
}

