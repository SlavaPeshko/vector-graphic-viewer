using DataParser.Data;
using DataParser.Factory;
using DataParser.Helpers;
using DataParser.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataParser.Services
{
	public class ParserFactoryResolver : IParserFactoryResolver
	{
		private readonly Dictionary<FileType, ParserFactory> _factories;

		public ParserFactoryResolver()
		{
			_factories = new Dictionary<FileType, ParserFactory>();

			foreach (FileType fileType in Enum.GetValues(typeof(FileType)).Cast<FileType>().Where(x => x != FileType.None))
			{
				var factory = (ParserFactory)Activator.CreateInstance(Type.GetType($"{typeof(ParserFactory).Namespace}.{Enum.GetName(typeof(FileType), fileType)}ParserFactory"));
				_factories.Add(fileType, factory);
			}
		}

		public IParser ExecuteCreation(string path) 
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (!File.Exists(path))
			{
				throw new FileNotFoundException(nameof(path));
			}

			var fileType = FileTypeHelper.GetFileType(path);

			if (_factories.TryGetValue(fileType, out ParserFactory parserFactory))
			{
				return parserFactory.Create(path);
			}

			return null;
		}
	}
}
