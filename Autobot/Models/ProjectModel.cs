using Autobot.Enums;
using Autobot.Helpers;

namespace Autobot.Models
{
	public class ProjectModel
	{
		public string ClientName { get; set; }

		public ProjectType ProjectType { get; set; }

		public ProjectCategory ProjectCategory { get; set; }

		public string RogueProjectName { get; set; }

		public string DatabaseConnectionName { get; set; } = string.Empty;

		public string PascalCaseProjectName { get; set; } = string.Empty;

		public string CamelCaseProjectName { get; set; } = string.Empty;

		public ProjectModel(
			string clientName,
			ProjectType projectType,
			ProjectCategory projectCategory,
			string rogueProjectName
		)
		{
			ClientName = clientName;
			ProjectType = projectType;
			ProjectCategory = projectCategory;
			RogueProjectName = rogueProjectName;
			InitializeProjectNameVariations();
		}

		private void InitializeProjectNameVariations()
		{
			var variants = ProjectHelper.GetProjectNameVariations(this);
			DatabaseConnectionName = variants[0];
			PascalCaseProjectName = variants[1];
			CamelCaseProjectName = variants[2];
		}
	}
}
