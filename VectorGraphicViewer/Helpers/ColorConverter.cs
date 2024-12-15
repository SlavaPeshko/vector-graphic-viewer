using System;
using System.Windows.Media;

namespace VectorGraphicViewer.Helpers
{
	public static class ColorConverter
	{
		public static SolidColorBrush ConvertStringToBrush(string colorString)
		{
			var components = colorString.Split(';');

			if (components.Length != 4)
				throw new ArgumentException(nameof(colorString));

			byte aplha = byte.Parse(components[0].Trim());
			byte red = byte.Parse(components[1].Trim());
			byte green = byte.Parse(components[2].Trim());
			byte blue = byte.Parse(components[3].Trim());

			var color = Color.FromArgb(aplha, red, green, blue);
			return new SolidColorBrush(color);
		}
	}
}
