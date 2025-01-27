using Autobot.Models;

namespace Autobot.Helpers
{
	public class ProjectHelper
	{
		public static List<string> GetProjectNameVariations(ProjectModel project)
		{
			var clientWords = project.ClientName.Split([' '], StringSplitOptions.RemoveEmptyEntries);

			var formattedName = string.Concat(clientWords.Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));

			var camelCaseName = char.ToLower(formattedName[0]) + formattedName[1..];

			var pascalCaseProjectName = $"{formattedName}{project.ProjectType}{project.ProjectCategory}";
			var camelCaseProjectName = $"{camelCaseName}{project.ProjectType}{project.ProjectCategory}";

			return [formattedName, pascalCaseProjectName, camelCaseProjectName];
		}

		public static void CreateAndWriteToFile(string subFolderPath, string fileNamePrefix, string fileContent, ProjectModel project)
		{
			var fileName = project.PascalCaseProjectName + fileNamePrefix + ".ts";
			var filePath = Path.Combine(Configuration.ConsumerPath + subFolderPath, fileName);

			try
			{
				if (!string.IsNullOrEmpty(Configuration.ConsumerPath + subFolderPath))
					Directory.CreateDirectory(Configuration.ConsumerPath + subFolderPath);

				using (FileStream fs = File.Create(Path.Combine(filePath)))
				{
					Console.WriteLine($"Arquivo '{fileName}' foi criado em '{subFolderPath}'");
				}

				using (StreamWriter writer = new StreamWriter(Path.Combine(filePath)))
				{
					writer.Write(fileContent);
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Um erro ocorreu durante a execução: {ex.Message}");
			}
		}
	}
}
