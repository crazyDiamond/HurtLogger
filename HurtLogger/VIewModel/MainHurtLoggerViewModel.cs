using System;

using Xamarin.Forms;

namespace HurtLogger
{
	public class MainHurtLoggerViewModel : ContentPage
	{
		public MainHurtLoggerViewModel ()
		{
			Padding = new Thickness (20);
			var listView = new ListView
			{
				RowHeight = 40
			};
			listView.ItemsSource = new string []
			{
				"Buy pears",
				"Buy oranges",
				"Buy mangos",
				"Buy apples",
				"Buy bananas"
			};
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { listView }
			};

		}
	}
}


