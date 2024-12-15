using System.Windows;
using System.Windows.Controls;
using VectorGraphicViewer.Models;

namespace VectorGraphicViewer.Selectors
{
	public class ShapeDataTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is Line)
			{
				return ((FrameworkElement)container).FindResource("LineTemplate") as DataTemplate;
			}

			if (item is Circle)
			{
				return ((FrameworkElement)container).FindResource("CircleTemplate") as DataTemplate;
			}

			if (item is Triangle)
			{
				return ((FrameworkElement)container).FindResource("TriangleTemplate") as DataTemplate;
			}

			return base.SelectTemplate(item, container);
		}
	}
}
