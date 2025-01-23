using Autobot.Models;

namespace Autobot.Helpers;

public static class ProjectHelper
{
	internal static void CreateAndWriteToFile(string pathFolder, string content, ProjectModel project)
	{
		var (pascalCaseProject, camelCaseProject) = project.GetProjectNameVariations();
		var fileName = pascalCaseProject + ".ts";
		var filePath = Path.Combine(Configuration.ConsumerPath + pathFolder, fileName);

		try
		{
			using (FileStream fs = File.Create(Path.Combine(filePath)))
			{
				Console.WriteLine($"File {fileName} was created in {pathFolder}");
			}

			using (StreamWriter writer = new StreamWriter(Path.Combine(filePath)))
			{
				writer.Write(content);
			}

		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred: {ex.Message}");
		}
	}
}
