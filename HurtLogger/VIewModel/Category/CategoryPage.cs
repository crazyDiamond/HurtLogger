using Xamarin.Forms;
using System.Diagnostics;
using System;

namespace HurtLogger
{
	public class CategoryPage: ContentPage
	{
		
		public CategoryPage (Category item){
			BindingContext = item;
			this.Title ="Manage Categories";
			this.BackgroundColor = Colors.HLPageBackground;
			this.SetBinding (Page.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var nameLabel = new LabelWithFont { FontFamily="FontAwesome", FontSize= 13, TextColor = Xamarin.Forms.Color.Gray, Text = "Category Name" };

			var nameEntry = new Entry ();
			nameEntry.SetBinding (Entry.TextProperty, "Name");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var category = (Category)BindingContext;
				Debug.WriteLine (DateTime.UtcNow);
				//User.LastUpdatedAt = DateTime.UtcNow;
				App.Database.SaveCategory(category);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				var category = (Category)BindingContext;
				App.Database.DeleteCategory(category.ID);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				this.Navigation.PopAsync();
			};


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, nameEntry, 
					saveButton, deleteButton, cancelButton
				}
			};
		}
	}
}






