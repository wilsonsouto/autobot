using Autobot.Controllers;

namespace Autobot.Views
{
	internal class ProjectView
	{
		internal static void RunMenu()
		{
			var projectController = new ProjectController();
			var result = projectController.GetUserInput();
		}
	}
}
