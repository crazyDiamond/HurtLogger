using System;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Labs.Controls;

namespace HurtLogger
{
	
	public class AddHurtLogPage: ContentPage
	{
		public Xamarin.Forms.Labs.Controls.CalendarView _calendarView;

		public User User {
			get;
			set;
		}

		public AddHurtLogPage (){
			this.Title ="Add Hurt Log";
			this.BackgroundColor = Colors.HLPageBackground;

			 _calendarView = new CalendarView() {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};


			NavigationPage.SetHasNavigationBar (this, true);
			var titleLabel = new Label { Text = "Title", TextColor = Colors.HLLabelTextColor};
			var titleEntry = new Entry ();
			titleEntry.SetBinding (Entry.TextProperty, "Title");


			var categoryLabel = new Label { Text = "Category", TextColor = Colors.HLLabelTextColor };
			var categoryEntry = new Entry ();
			categoryEntry.SetBinding (Entry.TextProperty, "Category");

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

			var _stacker = new StackLayout ();
			//Content = _stacker;
			_calendarView = new CalendarView() {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			//_stacker.Children.Add (_calendarView);
			_calendarView.DateSelected += (object sender, DateTime e) => {
				_stacker.Children.Add(new Label() 
					{ 
						Text = "Date Was Selected" + e.ToString("d"),
						VerticalOptions = LayoutOptions.Start,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					});
			};


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20),
				Children = {
					titleLabel, titleEntry, 
					categoryLabel, categoryEntry, descriptionLabel, _calendarView,
					descriptionEntry, saveButton, deleteButton, cancelButton
				}
			};
		}
	}
}


