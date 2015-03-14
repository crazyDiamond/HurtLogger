using System;
using Xamarin.Forms;

namespace HurtLogger
{
	public class HurtLogItemCell : ViewCell
	{
		public HurtLogItemCell(){

			var titleLabel = new Label {
				YAlign = TextAlignment.Center
			};
			titleLabel.SetBinding (Label.TextProperty, "Title");

			var tick = new Image {
				Source = ImageSource.FromFile ("check.png"),
			};
			tick.SetBinding (VisualElement.IsVisibleProperty, "IsAdmin");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {titleLabel, tick}
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



