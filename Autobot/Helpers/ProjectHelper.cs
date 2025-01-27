using Autobot.Models;
using Autobot.Enums;

namespace Autobot.Helpers
{
	public class ProjectHelper
	{
		public static List<string> GetProjectNameVariations(ProjectModel project)
		{
			var clientWords = project.ClientName.Split(
				[' '],
				StringSplitOptions.RemoveEmptyEntries
			);

			var formattedName = string.Concat(
				clientWords.Select(word => char.ToUpper(word[0]) + word[1..].ToLower())
			);

			var camelCaseName = char.ToLower(formattedName[0]) + formattedName[1..];

			var pascalCaseProjectName =
				$"{formattedName}{project.ProjectType}{project.ProjectCategory}";
			var camelCaseProjectName =
				$"{camelCaseName}{project.ProjectType}{project.ProjectCategory}";

			if (project.ProjectCategory != ProjectCategory.Psat)
			{
				pascalCaseProjectName =
					$"{formattedName}{project.ProjectType}{project.ProjectClassification}{project.ProjectCategory}";
				camelCaseProjectName =
					$"{camelCaseName}{project.ProjectType}{project.ProjectClassification}{project.ProjectCategory}";
			}

			return [formattedName, pascalCaseProjectName, camelCaseProjectName];
		}

		public static void CreateAndWriteToFile(
			string folderName,
			string filePrefix,
			string fileContent,
			ProjectModel project,
			bool isInterface
		)
		{
			var fileName = project.PascalCaseProjectName + filePrefix + ".ts";

			if (isInterface)
				fileName = "IMailing.ts";

			var filePath = Path.Combine(Configuration.ConsumerPath + folderName, fileName);

			try
			{
				if (!string.IsNullOrEmpty(Configuration.ConsumerPath + folderName))
					Directory.CreateDirectory(Configuration.ConsumerPath + folderName);

				using (FileStream fs = File.Create(Path.Combine(filePath)))
				{
					Console.WriteLine($"Arquivo '{fileName}' foi criado em '{folderName}'");
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
