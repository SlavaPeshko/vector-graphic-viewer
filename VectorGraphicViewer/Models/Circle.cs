using System.Windows.Media;

namespace VectorGraphicViewer.Models
{
	public class Circle : Shape
	{
		public double CenterX { get; set; }
		public double CenterY { get; set; }
		public double Diameter { get; set; }
		public SolidColorBrush Fill { get; set; }
	}
}
