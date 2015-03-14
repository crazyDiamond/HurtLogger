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
		static object locker = new object ();

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

		public int SaveItem (User item) 
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<User>(id);
			}
		}

	}
}

