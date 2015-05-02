using System;
using Xamarin.Forms.Platform.Android;
using HurtLogger;
using Xamarin.Forms;
using HurtLogger.Droid;
using Android.Graphics;

[assembly: ExportRenderer (typeof (LabelWithFont), typeof (LabelFontRenderer))]

namespace HurtLogger.Droid
{
	public class LabelFontRenderer : LabelRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);

			var label = Control;

			if(Element.FontFamily == "FontAwesome")
				label.Typeface = TrySetFont ("FontAwesome.otf");
		}

		private Typeface TrySetFont(string fontName)
		{
			try
			{
				return Typeface.CreateFromAsset(Context.Assets, fontName);
			} catch(Exception ex)
			{
				Console.WriteLine("not found in assets. Exception: {0}", ex);
				try
				{
					return Typeface.CreateFromFile("fonts/" + fontName);
				} catch(Exception ex1)
				{
					Console.WriteLine("not found by file. Exception: {0}", ex1);

					return Typeface.Default;
				}
			}
		}

	}
}
