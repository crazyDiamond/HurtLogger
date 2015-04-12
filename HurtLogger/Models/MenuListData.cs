using System.Collections.Generic;

namespace HurtLogger
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Users", 
				IconSource = "contracts.png", 
				TargetType = typeof(UsersListPage)
			});

			this.Add (new MenuItem () { 
				Title = "Hurt Logs", 
				IconSource = "hurtlog.jpg", 
				TargetType = typeof(HurtLogUserListPage)
			});
		

			this.Add (new MenuItem () {
				Title = "Reports",
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


