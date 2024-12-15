using System.Windows.Media;

namespace VectorGraphicViewer.Models
{
	public class Shape
	{
		public SolidColorBrush Color { get; set; }

		public double StrokeThickness { get; } = 1;
	}
}
