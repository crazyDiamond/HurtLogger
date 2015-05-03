
using Xamarin.Forms;

namespace HurtLogger
{
	public class UserItemCell :ViewCell
	{
		public UserItemCell(){

			var userNameLable = new LabelWithFont {
				YAlign = TextAlignment.Center,
				FontFamily="FontAwesome", 
				FontSize= 13, TextColor = 
				Xamarin.Forms.Color.Gray
			};
			userNameLable.SetBinding (Label.TextProperty, "Username");

			var tick = new Image {
				Source = ImageSource.FromFile ("check.png"),
			};
			tick.SetBinding (VisualElement.IsVisibleProperty, "IsAdmin");

			var layout = new StackLayout {
				BackgroundColor = Colors.HLPageBackground,
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {userNameLable, tick}
			};
			View = layout;
		}

		protected override void OnBindingContextChanged ()
		{
			// Fixme : this is happening because the View.Parent is getting 
			// set after the Cell gets the binding context set on it. Then it is inheriting
			// the parents binding context.
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}

	}
}


