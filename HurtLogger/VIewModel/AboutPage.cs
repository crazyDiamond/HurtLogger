using Xamarin.Forms;

namespace HurtLogger
{
	public class AboutPage: ContentPage
	{
		public AboutPage ()
		{
			this.BackgroundColor = Colors.HLPageBackground;
			this.Title = "About";

			var aboutLabel = new LabelWithFont{
				FontFamily="FontAwesome", 
				FontSize= 13, 
				TextColor = Xamarin.Forms.Color.Gray,
				Text="Hurt Logger is a tool that's meant to help you log a sickness or injury. This tool is meant to make logging simple. " };

			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone) { // WinPhone doesn't have the title showing
				layout.Children.Add(new Label{
					Text="Users", 
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))});
			}
			layout.Children.Add(aboutLabel);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

		}

	}
}





