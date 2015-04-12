using System.Collections.Generic;

namespace HurtLogger
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Profiles", 
				IconSource = "contracts.png", 
				TargetType = typeof(UsersListPage)
			});

			this.Add (new MenuItem () { 
				Title = "Add a Hurt Log", 
				IconSource = "hurtlog.jpg", 
				TargetType = typeof(HurtLogUserListPage)
			});
		

			this.Add (new MenuItem () {
				Title = "Recent Hurt Logs",
				IconSource = "reports.png",
				TargetType = typeof(HurtLogListPage)
			});

			this.Add (new MenuItem () {
				Title = "View Hurt Logs",
				IconSource = "reports.png",
				TargetType = typeof(ReportsListPage)
			});

			this.Add (new MenuItem () {
				Title = "About",
				IconSource = "about.png",
				TargetType = typeof(AboutPage)
			});


		}


	}


	
}


