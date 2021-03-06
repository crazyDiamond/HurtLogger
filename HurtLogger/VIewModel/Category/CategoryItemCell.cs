using Xamarin.Forms;

namespace HurtLogger
{
	public class CategoryItemCell :ViewCell
	{
		public CategoryItemCell(){

			var nameLabel = new LabelWithFont {
				YAlign = TextAlignment.Center,
				FontFamily="FontAwesome", 
				FontSize= 13, TextColor = 
					Xamarin.Forms.Color.Gray
				};
			nameLabel.SetBinding (Label.TextProperty, "Name");

			var layout = new StackLayout {
				BackgroundColor = Colors.HLPageBackground,
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {nameLabel}
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





