namespace DataParser.Interfaces
{
	public interface IParserFactoryResolver
	{
		IParser ExecuteCreation(string path);
	}
}
