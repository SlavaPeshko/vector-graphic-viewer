using DataParser.Interfaces;

namespace DataParser.Factory
{
	public abstract class ParserFactory
	{
		public abstract IParser Create(string path);
	}
}
