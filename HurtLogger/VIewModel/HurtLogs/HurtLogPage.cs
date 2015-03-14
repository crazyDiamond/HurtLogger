using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class HurtLogPage : ContentPage
	{
		public HurtLogPage (){

			this.Title ="Add Hurt Log";
			//this.SetBinding (Page.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var titleLabel = new Label { Text = "Title" };
			var titleEntry = new Entry ();

			titleEntry.SetBinding (Entry.TextProperty, "Title");

//			var selectUserLabel = new Label { Text = "Select User"};
//			var selectUserList = new ListView
//			{
//				RowHeight = 40
//			};
//			selectUserList.ItemsSource = new string []
//			{
//				"Jeeva",
//				"Kandhan"
//			};
//			selectUserList.SetBinding (Entry.TextProperty, "UserId");


			var categoryLabel = new Label { Text = "Category" };
			var categoryEntry = new Entry ();
			categoryEntry.SetBinding (Entry.TextProperty, "Category");

			var descriptionLabel = new Label { Text = "Description" };
			var descriptionEntry = new Entry ();
			descriptionEntry.SetBinding (Entry.TextProperty, "Description");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var hurtLogItem = (HurtLog)BindingContext;
				Debug.WriteLine (DateTime.UtcNow);
				hurtLogItem.Date = DateTime.UtcNow;
				App.Database.SaveHurtLog(hurtLogItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				var user = (User)BindingContext;
				App.Database.DeleteItem(user.ID);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				var user = (User)BindingContext;
				this.Navigation.PopAsync();
			};



			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				Children = {
					titleLabel, titleEntry, 
					categoryLabel, categoryEntry, descriptionLabel, 
					descriptionEntry, saveButton, deleteButton, cancelButton
				}
			};
		}
	}
}


