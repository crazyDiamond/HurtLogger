using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class CategoryListPage : ContentPage
	{
		readonly ListView listView;

		public CategoryListPage ()
		{
			this.BackgroundColor = Colors.HLPageBackground;
			this.Title = "Select a Category";


			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (CategoryItemCell));
			listView.BackgroundColor = Colors.HLPageBackground;
			listView.ItemSelected += (sender, e) => {
				var item = (Category)e.SelectedItem;
				var categoryPage = new CategoryPage(item);

				((App)Application.Current).ResumeAtUserId = item.ID;
				Debug.WriteLine("setting ResumeAtUserId = " + item.ID);

				Navigation.PushAsync(categoryPage);
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
			listView.ItemsSource = App.Database.GetAllCategories ();
		}
	}
}




