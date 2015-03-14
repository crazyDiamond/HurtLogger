﻿using System;

using Xamarin.Forms;

namespace HurtLogger
{
	public class UsersPage : ContentPage
	{
		public UsersPage (){
			this.Title ="Manage Users";
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);
			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new Entry ();

			nameEntry.SetBinding (Entry.TextProperty, "Name");

			var notesLabel = new Label { Text = "Notes" };
			var notesEntry = new Entry ();
			notesEntry.SetBinding (Entry.TextProperty, "Notes");

			var doneLabel = new Label { Text = "Done" };
			var doneEntry = new Switch ();
			doneEntry.SetBinding (Switch.IsToggledProperty, "Done");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var todoItem = (User)BindingContext;
				App.Database.SaveItem(todoItem);
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


			var speakButton = new Button { Text = "Speak" };
			speakButton.Clicked += (sender, e) => {
				var todoItem = (User)BindingContext;
				//DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					nameLabel, nameEntry, 
					notesLabel, notesEntry,
					doneLabel, doneEntry,
					saveButton, deleteButton, cancelButton,
					speakButton
				}
			};
		}
	}
}


