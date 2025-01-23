using Autobot.Services;

namespace Autobot.Views
{
	internal class ProjectView
	{
		internal static void RunMenu()
		{
			var projectService = new ProjectService();
			var result = projectService.GetUserInput();
			projectService.ConfigurationFile(result);
		}
	}
}
