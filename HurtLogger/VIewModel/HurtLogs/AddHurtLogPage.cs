using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace HurtLogger
{
	public class AddHurtLogPage: ContentPage
	{

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

//			var selectUserLabel = new Label { Text = "Select User", TextColor = Colors.HLLabelTextColor  };
//			var selectUserList = new ListView
//			{
//				RowHeight = 40
//			};


//			selectUserList.ItemsSource = App.Database.GetAllUsers ();
//			selectUserList.ItemTemplate = new DataTemplate(typeof(TextCell));
//			selectUserList.ItemTemplate.SetBinding (TextCell.TextProperty, "Username");
//			selectUserList.SetBinding(ListView.SelectedItemProperty, "UserId", BindingMode.TwoWay);

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

