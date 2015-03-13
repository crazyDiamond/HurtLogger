using System;
using System.IO;

namespace HurtLogger.Droid
{
	public class SQLite_Android : ISQLite
	{
		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "TodoSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);
			// Return the database connection 
			return conn;
		}

		#endregion

	}
}

