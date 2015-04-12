using Xamarin.Forms;

namespace HurtLogger
{
	public class HurtLogUserListPage: ContentPage
	{
		ListView listView;
		public HurtLogUserListPage ()
		{
			this.BackgroundColor = Colors.HLPageBackground;
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (UserItemCell));
			listView.BackgroundColor = Colors.HLPageBackground;
			listView.ItemSelected += (sender, e) => {
				var hurtLogItem = new HurtLog{
					UserId = ((User)e.SelectedItem).ID
				};

				var addHurtLogPage = new AddHurtLogPage();
				addHurtLogPage.BindingContext = hurtLogItem;
				Navigation.PushAsync(addHurtLogPage);

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
			((App)Application.Current).ResumeAtUserId = -1;
			listView.ItemsSource = App.Database.GetItems ();
		}
	}
}



