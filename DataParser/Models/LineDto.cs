using DataParser.Convertors;
using System.Text.Json.Serialization;

namespace DataParser.Models
{
	public class LineDto : ShapeDto
	{
		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto A { get; set; }

		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto B { get; set; }
	}
}
