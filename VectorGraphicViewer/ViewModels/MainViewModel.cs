using System.Threading.Tasks;

namespace VectorGraphicViewer.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel(ShapesViewModel shapesViewModel)
		{
			ShapesViewModel = shapesViewModel;
		}

		public ShapesViewModel ShapesViewModel { get; }

		public override async Task LoadAsync()
		{
			if (ShapesViewModel == null)
			{
				return;
			}

			await ShapesViewModel.LoadAsync();
		}
	}
}
