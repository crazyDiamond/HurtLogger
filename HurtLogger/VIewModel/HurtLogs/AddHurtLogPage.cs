using System;
using Xamarin.Forms;
using System.Diagnostics;
using XLabs.Forms.Controls;

namespace HurtLogger
{
	
	public class AddHurtLogPage: ContentPage
	{
		DatePicker dateDatePicker = new DatePicker{Format="D",Date=DateTime.Today}; 
		public User User {
			get;
			set;
		}

		public AddHurtLogPage (){
			this.Title ="Add Hurt Log";
			this.BackgroundColor = Colors.HLPageBackground;


			NavigationPage.SetHasNavigationBar (this, true);
			var titleLabel = new Label { Text = "Title", TextColor = Colors.HLLabelTextColor};
			var titleEntry = new Entry ();
			titleEntry.SetBinding (Entry.TextProperty, "Title");

			var dateLabel = new Label{ Text="Date", TextColor = Colors.HLLabelTextColor};

			dateDatePicker.SetBinding (DatePicker.DateProperty, "Date");

			var categoryLabel = new Label { Text = "Category", TextColor = Colors.HLLabelTextColor };
			ListView categoryListView = new ListView ();
			categoryListView.RowHeight = 20;
			categoryListView.ItemsSource = new string []
			{
				"Sick",
				"Sports Injury"
			};
			categoryListView.SetBinding (Entry.TextProperty, "Category");

			var descriptionLabel = new Label { Text = "Description", TextColor = Colors.HLLabelTextColor };
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
				var hurtLog = (HurtLog)BindingContext;
				App.Database.DeleteHurtLog(hurtLog.ID);
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
					titleLabel, titleEntry, dateLabel, dateDatePicker,
					categoryLabel, categoryListView, descriptionLabel, 
					descriptionEntry, saveButton, deleteButton, cancelButton
				}
			};


		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			this.dateDatePicker.Date = DateTime.Today;
		}
	}
}


