using DataParser.Convertors;
using System.Text.Json.Serialization;

namespace DataParser.Models
{
	public class CircleDto : ShapeDto
	{
		[JsonConverter(typeof(PointJsonConverter))]
		public PointDto Center { get; set; }
		public double Radius { get; set; }
	}
}
