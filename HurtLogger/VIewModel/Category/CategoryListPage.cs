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

			#region toolbar
			ToolbarItem tbi = null;
			if (Device.OS == TargetPlatform.Android) { 
				tbi = new ToolbarItem ("+", "plus", () => {
					var item = new Category();
					var categoryPage = new CategoryPage(item);
					categoryPage.BindingContext = item;
					Navigation.PushAsync(categoryPage);
				}, 0, 0);
			}
			#endregion

			ToolbarItems.Add (tbi);

			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			((App)Application.Current).ResumeAtUserId = -1;
			listView.ItemsSource = App.Database.GetAllCategories ();
		}
	}
}




