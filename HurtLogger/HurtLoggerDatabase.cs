﻿using System;
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
			database.CreateTable<HurtLog> ();
			database.CreateTable<Category> ();
		}

		public IEnumerable<User> GetItems () {
			return (from i in database.Table<User>() select i).ToList();
		}

		public IEnumerable<User> GetAllUsers ()
		{
			return database.Query<User>("SELECT ID, UserName FROM [User] ");
		}

		public IEnumerable<Category> GetAllCategories ()
		{
			return database.Query<Category>("SELECT ID, Name FROM [Category] ");
		}

		public IEnumerable<User> GetUserNames ()
		{
			return database.Query<User>("SELECT UserName FROM [User] ");
		}

		public System.Collections.IEnumerable GetAllHurtLogs ()
		{
			return database.Query<HurtLog>("SELECT H.ID, H.UserId, H.Title, H.Category, H.Description, H.Date, U.Username as UserName FROM [HurtLog] H JOIN [User] as U ON U.ID = H.UserId ORDER BY Date DESC ");
		}

		public System.Collections.IEnumerable GetAllHurtLogsByUserId (int userId)
		{
			var query = database.Query<HurtLog>("SELECT H.ID, H.UserId, H.Title, H.Category, H.Description, H.Date, U.Username as UserName FROM [HurtLog] H JOIN [User] as U ON U.ID = H.UserId WHERE U.ID = ? ORDER BY Date DESC ", userId);
			return query;
		}

		public User GetItem (int id) 
		{
			return database.Table<User>().FirstOrDefault(x => x.ID == id);
		}


		public int SaveUser (User item) 
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


		public int DeleteUser(int id)
		{
			lock (locker) {
				return database.Delete<User>(id);
			}
		}

		public int SaveCategory (Category item) 
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

		public int DeleteCategory(int id)
		{
			lock (locker) {
				return database.Delete<Category>(id);
			}
		}

		public int SaveHurtLog (HurtLog hurtLogItem)
		{
			lock (locker) {
				if (hurtLogItem.ID != 0) {
					database.Update(hurtLogItem);
					return hurtLogItem.ID;
				} else {
					return database.Insert(hurtLogItem);
				}
			}
		}

		public int DeleteHurtLog(int id)
		{
			lock (locker) {
				return database.Delete<HurtLog>(id);
			}
		}

	}
}

