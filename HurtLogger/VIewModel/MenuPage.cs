using System;

using Xamarin.Forms;

namespace HurtLogger
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set;}
		public MenuPage ()
		{
			Icon = "settings.png";
			Title = "Hurt Logger"; 
			BackgroundColor = Colors.HLMenuBackground;

			Menu = new MenuListView ();


//			var menuLabel = new ContentView {
//				Padding = new Thickness (10, 36, 0, 5),
//				Content = new Label {
//					TextColor = Color.White,
//					Text = "MENU"
//				},
//			};


			var menuImage = new Image{ Source = "hurtlogger80.png"
				};

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			//layout.Children.Add (menuLabel);
			layout.Children.Add (menuImage);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
	public class MenuItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}
}


