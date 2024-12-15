using DataParser.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VectorGraphicViewer.Mapper;
using VectorGraphicViewer.Models;

namespace VectorGraphicViewer.ViewModels
{
	public class ShapesViewModel : ViewModelBase
	{
		private readonly IParserFactoryResolver _parserFactoryResolver;

		public ShapesViewModel(IParserFactoryResolver parserFactoryResolver)
		{
			_parserFactoryResolver = parserFactoryResolver;
		}

		public ObservableCollection<Models.Shape> RenderedShapes { get; set; } = new ObservableCollection<Models.Shape>();

		public override async Task LoadAsync()
		{
			if (RenderedShapes.Any())
			{
				return;
			}

			var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"shapes.json");
			var shapes = await _parserFactoryResolver.ExecuteCreation(path).ParseShapesAsync();
			if (shapes == null)
			{
				return;
			}

			foreach (var shape in shapes)
			{
				Shape model = null;

				switch (shape)
				{
					case DataParser.Models.LineDto line:
						model = line.ToModel();
						break;
					case DataParser.Models.CircleDto circle:
						model = circle.ToModel();
						break;
					case DataParser.Models.TriangleDto triangle:
						model = triangle.ToModel();
						break;
					default:
						break;
				}

				if (model != null)
				{
					RenderedShapes.Add(model);
				}
			}
		}
	}
}
