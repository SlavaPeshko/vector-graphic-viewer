using DataParser.Services;

namespace DataParser.Tests
{
	public class ParserFactoryResolverTests
	{
		private ParserFactoryResolver _resolver;

		[SetUp]
		public void Setup()
		{
			_resolver = new ParserFactoryResolver();
		}

		[Test]
		[TestCase(null!)]
		[TestCase("")]
		public void ExecuteCreation_WhenPathIsNullOrEmpty_ThrowsArgumentNullException(string path)
		{
			_ = Assert.Throws<ArgumentNullException>(() => _resolver.ExecuteCreation(null));
		}

		[Test]
		public void ExecuteCreation_WhenFileDoesNotExist_ThrowsFileNotFoundException()
		{
			Assert.Throws<FileNotFoundException>(() => _resolver.ExecuteCreation("nonexistent.json"));
		}

		[Test]
		public void ExecuteCreation_WithValidJsonFile_ReturnsJsonParser()
		{
			// Act
			var parser = _resolver.ExecuteCreation(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\shapes.json"));
			parser.ParseShapesAsync();
			// Assert
			Assert.That(parser, Is.Not.EqualTo(null));
			Assert.That(parser, Is.InstanceOf<JsonParserManager>());
		}

		[Test]
		public void ExecuteCreation_WithUnsupportedFileType_ReturnsNull()
		{
			// Act
			var parser = _resolver.ExecuteCreation(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\test.txt"));

			// Assert
			Assert.That(parser, Is.EqualTo(null));
		}
	}
}
