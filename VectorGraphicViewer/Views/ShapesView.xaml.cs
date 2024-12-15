using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Helpers;

namespace VectorGraphicViewer.Views
{
	/// <summary>
	/// Interaction logic for ShapesView.xaml
	/// </summary>
	public partial class ShapesView : UserControl
	{
		public ShapesView()
		{
			InitializeComponent();
		}

		private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var zoomLevel = zoomSlider.Value / 100.0;

			if (itemsControl == null)
			{
				return;
			}

			var itemsPresenter = DependencyObjectHelper.FindVisualChild<ItemsPresenter>(itemsControl);
			var canvas = DependencyObjectHelper.FindVisualChild<Canvas>(itemsPresenter);
			if (canvas == null)
			{
				return;
			}

			var scaleTransform = canvas.RenderTransform as ScaleTransform;
			if (scaleTransform != null)
			{
				scaleTransform.ScaleX = zoomLevel;
				scaleTransform.ScaleY = zoomLevel;
			}
		}
	}
}
