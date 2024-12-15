using System;
using System.Globalization;
using System.Windows.Data;

namespace VectorGraphicViewer.Convertors
{
	public class CenterToCanvasOffsetConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double radius = double.Parse(parameter?.ToString() ?? "0");
			return (double)value - radius;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
