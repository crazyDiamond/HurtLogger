using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class UsersPage : ContentPage
	{
		public UsersPage (){
			this.Title ="Manage Users";
			this.SetBinding (Page.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var nameLabel = new Label { Text = "User Name" };
			var nameEntry = new Entry ();

			nameEntry.SetBinding (Entry.TextProperty, "Username");

			var selectSexLabel = new Label { Text = "Select Sex"};
			var selectSexList = new ListView
			{
				RowHeight = 40
			};
			selectSexList.ItemsSource = new string []
			{
				"Male",
				"Female"
			};
			selectSexList.SetBinding (Entry.TextProperty, "Sex");


			var notesLabel = new Label { Text = "Age" };
			var notesEntry = new Entry ();
			notesEntry.SetBinding (Entry.TextProperty, "Age");

			var doneLabel = new Label { Text = "Admin" };
			var doneEntry = new Switch ();
			doneEntry.SetBinding (Switch.IsToggledProperty, "IsAdmin");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var userItem = (User)BindingContext;
				Debug.WriteLine (DateTime.UtcNow);
				userItem.LastUpdatedAt = DateTime.UtcNow;
				App.Database.SaveUser(userItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				var user = (User)BindingContext;
				App.Database.DeleteUser(user.ID);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				var user = (User)BindingContext;
				this.Navigation.PopAsync();
			};


			var speakButton = new Button { Text = "Speak" };
			speakButton.Clicked += (sender, e) => {
				var todoItem = (User)BindingContext;
				//DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, nameEntry, 
					selectSexLabel, selectSexList,
					notesLabel, notesEntry,
					doneLabel, doneEntry,
					saveButton, deleteButton, cancelButton,
					speakButton
				}
			};
		}
	}
}


