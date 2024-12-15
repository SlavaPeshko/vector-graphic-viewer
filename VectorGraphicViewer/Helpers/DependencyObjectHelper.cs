using System.Windows.Media;
using System.Windows;

namespace VectorGraphicViewer.Helpers
{
	public static class DependencyObjectHelper
	{
		public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				if (child is T t)
				{
					return t;
				}

				var result = FindVisualChild<T>(child);
				if (result != null)
				{
					return result;
				}
			}
			return null;
		}
	}
}
