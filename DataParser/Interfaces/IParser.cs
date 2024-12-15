using DataParser.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataParser.Interfaces
{
	public interface IParser
	{
		Task<IEnumerable<ShapeDto>> ParseShapesAsync();
	}
}