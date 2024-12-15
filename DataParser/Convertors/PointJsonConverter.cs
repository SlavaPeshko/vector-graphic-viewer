using DataParser.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataParser.Convertors
{
	public class PointJsonConverter : JsonConverter<PointDto>
	{
		public override PointDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string value = reader.GetString();
			if (value == null)
			{
				throw new JsonException(nameof(value));
			}

			var parts = value.Split(';');
			if (parts.Length != 2)
			{
				throw new JsonException("Invalid Point format. Expected 'X; Y'.");
			}

			return new PointDto
			{
				X = double.Parse(parts[0].Replace(',', '.')),
				Y = double.Parse(parts[1].Replace(',', '.')),
			};
		}

		public override void Write(Utf8JsonWriter writer, PointDto value, JsonSerializerOptions options)
		{
			string pointString = $"{value.X.ToString().Replace(".", ",")}; {value.Y.ToString().Replace(".", ",")}";
			writer.WriteStringValue(pointString);
		}
	}
}
