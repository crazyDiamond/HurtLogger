using System.Collections.Generic;

namespace HurtLogger
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Profiles", 
				IconSource = "profile.png", 
				TargetType = typeof(UsersListPage)
			});

			this.Add (new MenuItem () { 
				Title = "Add a Hurt Log", 
				IconSource = "plus24.png", 
				TargetType = typeof(HurtLogUserListPage)
			});
		

			this.Add (new MenuItem () {
				Title = "Recent Hurt Logs",
				IconSource = "recent.png",
				TargetType = typeof(HurtLogListPage)
			});

			this.Add (new MenuItem () {
				Title = "View Hurt Logs",
				IconSource = "view.png",
				TargetType = typeof(ReportsListPage)
			});

			this.Add (new MenuItem () {
				Title = "Categories",
				IconSource = "category.png",
				TargetType = typeof(CategoryListPage)
			});

			this.Add (new MenuItem () {
				Title = "About",
				IconSource = "about.png",
				TargetType = typeof(AboutPage)
			});


		}


	}


	
}


