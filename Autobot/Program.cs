using Autobot.Services;
using Autobot.Views;

namespace Autobot
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			while (true)
			{
				var project = ProjectView.RunMenu();

				ProjectService service = new();
				service.GenerateConfigurationFile(project);
				service.GenerateConnectionFile(project);
				service.GenerateEntitiesFile(project);
				service.GenerateFactoryFile(project);
				service.GenerateInterfaceFile(project);
				service.GenerateRepositoryFile(project);
				service.GenerateServiceFile(project);
				service.GenerateStrategyFile(project);
			}
		}
	}
}