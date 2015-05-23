using Xamarin.Forms;

namespace HurtLogger
{
	public class HurtLogPage : ContentPage
	{
		DatePicker dateDatePicker = new DatePicker{Format="D"}; 
		public User User {
			get;
			set;
		}
		public HurtLogPage (){

			this.Title ="Edit Hurt Log";
			this.BackgroundColor = Colors.HLPageBackground;


			NavigationPage.SetHasNavigationBar (this, true);
			var titleLabel = new LabelWithFont { 
				Text = "Title", 
				FontFamily="FontAwesome", 
				FontSize= 13, 
				TextColor = Xamarin.Forms.Color.Gray};
			var titleEntry = new Entry ();
			titleEntry.SetBinding (Entry.TextProperty, "Title");

			var dateLabel = new Label{ Text="Date", TextColor = Colors.HLLabelTextColor};
			dateDatePicker.SetBinding (DatePicker.DateProperty, "Date");


//			var selectUserLabel = new Label { Text = "Select User", TextColor = Colors.HLLabelTextColor  };
//			var selectUserList = new ListView
//			{
//				RowHeight = 40
//			};
//
//			selectUserList.ItemsSource = App.Database.GetAllUsers ();
//			selectUserList.ItemTemplate = new DataTemplate(typeof(TextCell));
//			selectUserList.ItemTemplate.SetBinding (TextCell.TextProperty, "Username");
//			selectUserList.SetBinding(ListView.SelectedItemProperty, "UserId", BindingMode.TwoWay);

			var nameLabel = new Label{Text="Name", TextColor = Colors.HLLabelTextColor };
			var nameEntry = new Entry ();
			nameEntry.SetBinding (Entry.TextProperty, "UserName");

			var categoryLabel = new Label { Text = "Category", TextColor = Colors.HLLabelTextColor };
			var categoryEntry = new Entry ();
			categoryEntry.SetBinding (Entry.TextProperty, "Category");

			var descriptionLabel = new Label { Text = "Description", TextColor = Colors.HLLabelTextColor };
			var descriptionEntry = new Editor ();
			descriptionEntry.SetBinding (Editor.TextProperty, "Description");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += (sender, e) => {
				var hurtLogItem = (HurtLog)BindingContext;
				hurtLogItem.Date = dateDatePicker.Date;
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
					titleLabel, titleEntry, nameLabel, nameEntry,
					dateLabel, dateDatePicker,
					categoryLabel, categoryEntry, descriptionLabel,
					descriptionEntry, saveButton, deleteButton, cancelButton
				}
			};

		}

	}
}


