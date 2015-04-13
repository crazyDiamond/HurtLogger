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
			this.Title = "Select a profile";


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


