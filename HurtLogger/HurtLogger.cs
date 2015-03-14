using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class App : Application
	{
		static HurtLogger.DatabaseAccessor database;

		public App ()
		{
			// The root page of your application
			MainPage = new RootPage ();
		}

		public static DatabaseAccessor Database {
			get { 
				if (database == null) {
					database = new DatabaseAccessor ();
				}
				return database; 
			}
		}

		public int ResumeAtUserId { get; set; }

		protected override void OnStart ()
		{
			if (Properties.ContainsKey ("ResumeAtTodoId")) {
				var rati = Properties ["ResumeAtTodoId"].ToString();
				Debug.WriteLine ("   rati="+rati);
				if (!String.IsNullOrEmpty (rati)) {
					Debug.WriteLine ("   rati = " + rati);
					ResumeAtUserId = int.Parse (rati);

					if (ResumeAtUserId >= 0) {
						var todoPage = new RootPage ();
						todoPage.BindingContext = Database.GetItem (ResumeAtUserId);

						MainPage.Navigation.PushAsync (
							todoPage,
							false); // no animation
					}
				}
			}
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

