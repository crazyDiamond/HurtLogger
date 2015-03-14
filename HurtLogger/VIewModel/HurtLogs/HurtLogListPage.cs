using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class HurtLogListPage : ContentPage
	{
		ListView listView;
		public HurtLogListPage ()
		{
			Title = "Hurt Log";

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (HurtLogItemCell));
			listView.ItemSelected += (sender, e) => {
				var hurtLogItem = (HurtLog)e.SelectedItem;
				var hurtLogPage = new HurtLogPage();
				hurtLogPage.BindingContext = hurtLogItem;

				((App)Application.Current).ResumeAtUserId = hurtLogItem.UserId;
				Debug.WriteLine("setting ResumeAtUserId = " + hurtLogItem.UserId);

				Navigation.PushAsync(hurtLogPage);
			};

			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone) { // WinPhone doesn't have the title showing
				layout.Children.Add(new Label{
					Text="Hurt Log", 
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
						var hurtLogItem = new HurtLog();
						var hurtLogPage = new HurtLogPage();
						hurtLogPage.BindingContext = hurtLogItem;
						Navigation.PushAsync(hurtLogPage);
					}, 0, 0);
			}
			if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
				tbi = new ToolbarItem ("+", "plus", () => {
					var hurtLogItem = new HurtLog();
					var hurtLogPage = new HurtLogPage();
					hurtLogPage.BindingContext = hurtLogItem;
					Navigation.PushAsync(hurtLogPage);
				}, 0, 0);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				tbi = new ToolbarItem("Add", "add.png", () =>
					{
						var hurtLogItem = new HurtLog();
						var hurtLogPage = new HurtLogPage();
						hurtLogPage.BindingContext = hurtLogItem;
						Navigation.PushAsync(hurtLogPage);
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


