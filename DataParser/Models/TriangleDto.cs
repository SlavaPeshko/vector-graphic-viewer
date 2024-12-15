using DataParser.Convertors;
using System.Text.Json.Serialization;

namespace DataParser.Models
{
	public class TriangleDto : ShapeDto
	{
		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto A { get; set; }

		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto B { get; set; }

		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto C { get; set; }
	}
}
