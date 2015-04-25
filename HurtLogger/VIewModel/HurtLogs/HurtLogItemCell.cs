using System;
using Xamarin.Forms;

namespace HurtLogger
{
	public class HurtLogItemCell : ViewCell
	{
		public HurtLogItemCell(){

			var nameLabel = new Label{ YAlign = TextAlignment.Center };
			nameLabel.SetBinding (Label.TextProperty, "UserName");

			var titleLabel = new Label { YAlign = TextAlignment.Center};
			titleLabel.SetBinding (Label.TextProperty, "Title");

			var dateLabel = new Label{YAlign = TextAlignment.Center };
			dateLabel.SetBinding(Label.TextProperty, new Binding(path: "Date", stringFormat: "{0:MM/dd/yyyy}"));


			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {nameLabel, titleLabel, dateLabel}
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



