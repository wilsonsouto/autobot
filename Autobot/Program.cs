using Autobot.Services;
using Autobot.Views;

internal class Program
{
	private static void Main(string[] args)
	{
		var project = ProjectView.RunMenu();

		ProjectService service = new();
		service.ConfigurationFile(project);
		service.ConnectionFile(project);
		service.EntitiesFile(project);
		service.FactoryFile(project);
	}
}
