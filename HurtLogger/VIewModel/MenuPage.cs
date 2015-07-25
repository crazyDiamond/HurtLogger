using System;
using Xamarin.Forms;

namespace HurtLogger
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set;}
		public MenuPage ()
		{
			Icon = "hamburger.png";
			Title = "Hurt Logger"; 
			BackgroundColor = Colors.HLMenuBackground;

			Menu = new MenuListView (){};

			var menuImage = new Image{ Source = "../drawable-hdpi/ic_launcher.png"
				};

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};


			Menu.Header = "Hurt Logger";
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


