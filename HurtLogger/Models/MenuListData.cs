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
				TargetType = typeof(UsersPage)
			});

			this.Add (new MenuItem () { 
				Title = "Reports", 
				IconSource = "Lead.png", 
				TargetType = typeof(ReportsPage)
			});

			this.Add (new MenuItem () { 
				Title = "Accounts", 
				IconSource = "Accounts.png", 
				TargetType = typeof(AccountsPage)
			});

			this.Add (new MenuItem () {
				Title = "Opportunities",
				IconSource = "Opportunity.png",
				TargetType = typeof(OpportunitiesPage)
			});

		}


	}


	
}


