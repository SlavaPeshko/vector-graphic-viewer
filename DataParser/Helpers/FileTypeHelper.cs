using DataParser.Data;

namespace DataParser.Helpers
{
	public static class FileTypeHelper
	{
		private const string JsonExtension = ".json";

		public static FileType GetFileType(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return FileType.None;
			}

			switch (path)
			{
				case var _ when path.EndsWith(JsonExtension, System.StringComparison.OrdinalIgnoreCase):
					return FileType.Json;
				default:
					return FileType.None;
			}
		}
	}
}
