
using SQLite.Net;

public interface ISQLite {
	SQLiteConnection GetConnection();
}
