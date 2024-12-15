using DataParser.Interfaces;
using DataParser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VectorGraphicViewer.ViewModels;

namespace VectorGraphicViewer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IServiceProvider _serviceProvider;

		public App()
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);

			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow?.Show();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IParserFactoryResolver, ParserFactoryResolver>();
			services.AddTransient<MainWindow>();
			services.AddTransient<MainViewModel>();
			services.AddTransient<ShapesViewModel>();
		}
	}
}
