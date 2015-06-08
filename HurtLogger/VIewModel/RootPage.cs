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
			Detail = new NavigationPage (new UsersListPage ());

		}

		void NavigateTo (MenuItem menu)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = new NavigationPage (displayPage);

			IsPresented = false;
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


