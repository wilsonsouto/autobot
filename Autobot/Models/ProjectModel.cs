using Autobot.Enums;
using Autobot.Helpers;

namespace Autobot.Models
{
	public class ProjectModel
	{
		public string ClientName { get; }

		public string RogueProjectName { get; }

		public ProjectType ProjectType { get; }

		public ProjectCategory ProjectCategory { get; }

		public ProjectClassification ProjectClassification { get; }

		public string DatabaseConnectionName { get; private set; } = string.Empty;

		public string PascalCaseProjectName { get; private set; } = string.Empty;

		public string CamelCaseProjectName { get; private set; } = string.Empty;

		public ProjectModel(string clientName, string rogueProjectName, ProjectType projectType, ProjectCategory projectCategory)
		{
			ClientName = clientName;
			RogueProjectName = rogueProjectName;
			ProjectType = projectType;
			ProjectCategory = projectCategory;
			InitializeProjectNameVariations();
		}

		public ProjectModel(string clientName, string rogueProjectName, ProjectType projectType, ProjectCategory projectCategory, ProjectClassification projectClassification)
		{
			ClientName = clientName;
			RogueProjectName = rogueProjectName;
			ProjectType = projectType;
			ProjectCategory = projectCategory;
			ProjectClassification = projectClassification;
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