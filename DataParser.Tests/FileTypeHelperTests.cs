using DataParser.Data;
using DataParser.Helpers;

namespace DataParser.Tests
{
	public class FileTypeHelperTests
	{
		[TestCase(null!, ExpectedResult = FileType.None)]
		[TestCase("", ExpectedResult = FileType.None)]
		[TestCase("test.json", ExpectedResult = FileType.Json)]
		[TestCase("test.JSON", ExpectedResult = FileType.Json)]
		[TestCase("test.txt", ExpectedResult = FileType.None)]
		[TestCase("test.json.txt", ExpectedResult = FileType.None)]
		public FileType GetFileType_ReturnsExpectedResult(string path)
		{
			return FileTypeHelper.GetFileType(path);
		}
	}
}
