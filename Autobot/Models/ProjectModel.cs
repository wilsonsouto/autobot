using Autobot.Enums;

namespace Autobot.Models
{
	public class ProjectModel(string clientName, ProjectType projectType, ProjectCategory projectCategory, string rogueProjectName)
	{
		public string ClientName { get; set; } = clientName;

		public ProjectType ProjectType { get; set; } = projectType;

		public ProjectCategory ProjectCategory { get; set; } = projectCategory;

		public string RogueProjectName { get; set; } = rogueProjectName;
	}
}
