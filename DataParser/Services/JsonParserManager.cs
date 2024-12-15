using DataParser.Interfaces;
using DataParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataParser.Services
{
	public class JsonParserManager : IParser
	{
		private readonly string _path;
		private readonly JsonSerializerOptions _jsonSerializerOptions;
		
		public JsonParserManager(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (!File.Exists(path))
			{
				throw new FileNotFoundException(nameof(path));
			}

			_path = path;
			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
		}

		public async Task<IEnumerable<ShapeDto>> ParseShapesAsync()
		{
			try
			{
				using (var stream = File.OpenRead(_path))
				{
					return await DeserializeShapesAsync(stream);
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"An error occurred while processing the JSON file at '{_path}'.", ex);
			}
		}

		private async Task<IEnumerable<ShapeDto>> DeserializeShapesAsync(Stream stream)
		{
			var shapes = new List<ShapeDto>();
			using (var jsonDocument = await JsonDocument.ParseAsync(stream).ConfigureAwait(false))
			{
				foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
				{
					if (!jsonElement.TryGetProperty(Constants.Type, out JsonElement element))
					{
						continue;
					}

					var type = element.GetString()?.ToLowerInvariant();

					switch (type)
					{
						case var value when string.Equals(value, Constants.Line):
							shapes.Add(jsonElement.Deserialize<LineDto>(_jsonSerializerOptions));
							break;
						case var value when string.Equals(value, Constants.Circle):
							shapes.Add(jsonElement.Deserialize<CircleDto>(_jsonSerializerOptions));
							break;
						case var value when string.Equals(value, Constants.Triangle):
							shapes.Add(jsonElement.Deserialize<TriangleDto>(_jsonSerializerOptions));
							break;
						default:
							break;
					}
				}
			}

			return shapes;
		}
	}
}
