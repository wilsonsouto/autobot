using Autobot.Enums;

namespace Autobot.Models
{
	public class ProjectModel(string clientName, ProjectType projectType, ProjectCategory projectCategory, string rogueProjectName)
	{
		public string ClientName { get; set; } = clientName;

		public ProjectType ProjectType { get; set; } = projectType;

		public ProjectCategory ProjectCategory { get; set; } = projectCategory;

		public string RogueProjectName { get; set; } = rogueProjectName;

		public (string, string) GetProjectNameVariations()
		{
			if (string.IsNullOrEmpty(ClientName))
				return (string.Empty, string.Empty);

			var words = ClientName.Split([' '], StringSplitOptions.RemoveEmptyEntries);

			var pascalCase = string.Concat(words.Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));

			var camelCase = char.ToLower(pascalCase[0]) + pascalCase[1..];

			var pascalCaseProject = $"{pascalCase}{ProjectType}{ProjectCategory}";
			var camelCaseProject = $"{camelCase}{ProjectType}{ProjectCategory}";

			return (pascalCaseProject, camelCaseProject);
		}
	}
}
