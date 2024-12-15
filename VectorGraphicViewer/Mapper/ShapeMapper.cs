using DataParser.Models;
using VectorGraphicViewer.Helpers;

namespace VectorGraphicViewer.Mapper
{
	public static class ShapeMapper
	{
		public static Models.Line ToModel(this LineDto dto)
		{
			if (dto == null)
			{
				return null;
			}

			return new Models.Line
			{
				X1 = dto.A.X,
				Y1 = dto.A.Y,
				X2 = dto.B.X,
				Y2 = dto.B.Y,
				Color = ColorConverter.ConvertStringToBrush(dto.Color),
			};
		}

		public static Models.Circle ToModel(this CircleDto dto)
		{
			if (dto == null)
			{
				return null;
			}

			var color = ColorConverter.ConvertStringToBrush(dto.Color);

			return new Models.Circle
			{
				CenterX = dto.Center.X,
				CenterY = dto.Center.X,
				Diameter = dto.Radius * 2,
				Color = color,
				Fill = dto.Filled.HasValue && dto.Filled.Value ? color : null
			};
		}

		public static Models.Triangle ToModel(this TriangleDto dto)
		{
			if (dto == null)
			{
				return null;
			}

			var color = ColorConverter.ConvertStringToBrush(dto.Color);

			return new Models.Triangle
			{
				Points = $"{dto.A.X},{dto.A.Y} {dto.B.X},{dto.B.Y} {dto.C.X},{dto.C.Y}",
				Color = color,
				Fill = dto.Filled.HasValue && dto.Filled.Value ? color : null
			};
		}
	}
}
