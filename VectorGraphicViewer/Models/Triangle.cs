using System.Windows.Media;

namespace VectorGraphicViewer.Models
{
	public class Triangle : Shape
	{
		public string Points { get; set; }
		public SolidColorBrush Fill { get; set; }
	}
}
