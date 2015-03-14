using System;

using Xamarin.Forms;

namespace HurtLogger
{
	public class RootPage : MasterDetailPage
	{
		public RootPage ()
		{

			var menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
			Master = menuPage;
			Detail = new NavigationPage (new UsersPage ());

		}

		void NavigateTo (MenuItem menu)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = new NavigationPage (displayPage);

			IsPresented = false;
		}
	}


	public class ReportsPage : ContentPage
	{
		public ReportsPage (){
			this.Title = "Reports";
		}
	}

	public class AccountsPage : ContentPage
	{
		public AccountsPage (){
			this.Title = "Accounts";
		}
	}

	public class OpportunitiesPage : ContentPage
	{
		public OpportunitiesPage (){
			this.Title = "Opportunities";
		}
	}
	public enum MasterBehavior
	{
		Default,
		Popover,
		Split,
		SplitOnLandscape,
		SplitOnPortrait
	}
}


