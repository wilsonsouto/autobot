using Autobot.Services;
using Autobot.Views;

internal class Program
{
	private static void Main(string[] args)
	{
		var project = ProjectView.RunMenu();

		ProjectService service = new();
		service.GenerateConfigurationFile(project);
		service.GenerateConnectionFile(project);
		service.GenerateEntitiesFile(project);
		service.GenerateFactoryFile(project);
		service.GenerateInterfaceFile(project);
		service.GenerateRepositoryFile(project);
	}
}
