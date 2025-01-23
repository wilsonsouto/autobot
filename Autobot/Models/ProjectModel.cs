using Autobot.Enums;

namespace Autobot.Models
{
	public class ProjectModel(string clientName, ProjectType projectType, ProjectCategory projectCategory, string rogueProjectName)
	{
		internal string ClientName { get; set; } = clientName;

		internal ProjectType ProjectType { get; set; } = projectType;

		internal ProjectCategory ProjectCategory { get; set; } = projectCategory;

		internal string RogueProjectName { get; set; } = rogueProjectName;
	}
}
