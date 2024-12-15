using DataParser.Interfaces;
using DataParser.Services;

namespace DataParser.Factory
{
	public class JsonParserFactory : ParserFactory
	{
		public override IParser Create(string path) => new JsonParserManager(path);
	}
}
