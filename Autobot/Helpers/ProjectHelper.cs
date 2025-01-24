using Autobot.Models;

namespace Autobot.Helpers
{
	public class ProjectHelper
	{
		public static List<string> GetProjectNameVariations(ProjectModel project)
		{
			var words = project.ClientName.Split([' '], StringSplitOptions.RemoveEmptyEntries);

			var pascalCase = string.Concat(words.Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));

			var camelCase = char.ToLower(pascalCase[0]) + pascalCase[1..];

			var pascalCaseProjectName = $"{pascalCase}{project.ProjectType}{project.ProjectCategory}";
			var camelCaseProjectName = $"{camelCase}{project.ProjectType}{project.ProjectCategory}";

			return [pascalCaseProjectName, camelCaseProjectName];
		}

		public static void CreateAndWriteToFile(string pathFolder, string filePrefix, string content, ProjectModel project)
		{
			var fileName = project.PascalCaseProjectName + filePrefix + ".ts";
			var filePath = Path.Combine(Configuration.ConsumerPath + pathFolder, fileName);

			try
			{
				using (FileStream fs = File.Create(Path.Combine(filePath)))
				{
					Console.WriteLine($"Arquivo '{fileName}' foi criado em '{pathFolder}'");
				}

				using (StreamWriter writer = new StreamWriter(Path.Combine(filePath)))
				{
					writer.Write(content);
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Um erro ocorreu durante a execução: {ex.Message}");
			}
		}
	}
}
