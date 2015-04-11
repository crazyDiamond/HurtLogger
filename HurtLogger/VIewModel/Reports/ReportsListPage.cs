using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class ReportsListPage : ContentPage
	{
		readonly ListView listView;
		public ReportsListPage ()
		{
			this.BackgroundColor = Colors.HLPageBackground;


			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (UserItemCell));
			listView.BackgroundColor = Colors.HLPageBackground;
			listView.ItemSelected += (sender, e) => {
				var userItem = (User)e.SelectedItem;
				var userPage = new UsersPage(userItem);

				((App)Application.Current).ResumeAtUserId = userItem.ID;
				Debug.WriteLine("setting ResumeAtUserId = " + userItem.ID);

				Navigation.PushAsync(userPage);
			};

			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone) { // WinPhone doesn't have the title showing
				layout.Children.Add(new Label{
					Text="Users", 
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))});
			}
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			#region toolbar
			ToolbarItem tbi = null;
			if (Device.OS == TargetPlatform.iOS)
			{
				tbi = new ToolbarItem("+", null, () =>
					{
						var userItem = new User();
						var userPage = new UsersPage(userItem);
						userPage.BindingContext = userItem;
						Navigation.PushAsync(userPage);
					}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var userItem = new User();
					var userPage = new UsersPage(userItem);
					userPage.BindingContext = userItem;
					Navigation.PushAsync(userPage);
				}, 0, 0);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				tbi = new ToolbarItem("Add", "add.png", () =>
					{
						var userItem = new User();
						var userPage = new UsersPage(userItem);
						userPage.BindingContext = userItem;
						Navigation.PushAsync(userPage);
					}, 0, 0);
			}

			ToolbarItems.Add (tbi);


			#endregion
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			// reset the 'resume' id, since we just want to re-start here
			((App)Application.Current).ResumeAtUserId = -1;
			listView.ItemsSource = App.Database.GetItems ();
		}
	}
}


