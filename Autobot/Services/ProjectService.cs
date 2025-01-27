using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;

namespace Autobot.Services
{
	public interface IProjectService
	{
		void GenerateConfigurationFile(ProjectModel project);

		void GenerateConnectionFile(ProjectModel project);

		void GenerateEntitiesFile(ProjectModel project);

		void GenerateFactoryFile(ProjectModel project);

		void GenerateInterfaceFile(ProjectModel project);

		void GenerateRepositoryFile(ProjectModel project);

		void GenerateServiceFile(ProjectModel project);

		void GenerateStrategyFile(ProjectModel project);
	}

	public class ProjectService : IProjectService
	{
		public void GenerateConfigurationFile(ProjectModel project)
		{
			var folderName = "config";
			var filePrefix = "Config";

			var connectionName =
				$"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectCategory}".ToUpper();

			var templateFilePath = Path.Combine(Configuration.DataPath, "Config/Config.txt");
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{databaseConnectionName}}", connectionName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}

		public void GenerateConnectionFile(ProjectModel project)
		{
			var folderName = "database/connections";
			var filePrefix = "Connection";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				"Connection/Connection.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}

		public void GenerateEntitiesFile(ProjectModel project)
		{
			var entitiesDictionary = new Dictionary<int, string>
			{
				{ 1, "Atendimento" },
				{ 2, "Evento" },
				{ 3, "NocApiStatus" },
				{ 4, "OlosStatus" },
				{ 5, "Survey" },
				{ 6, "Tabulacao" },
			};

			if (project.ProjectCategory != ProjectCategory.Psat)
				entitiesDictionary.Remove(5);

			foreach (KeyValuePair<int, string> entity in entitiesDictionary)
			{
				var folderName = $"models/entities/{project.CamelCaseProjectName}";
				var filePrefix = entity.Value;

				var templateFilePath = Path.Combine(
					Configuration.DataPath,
					$"Entities/{project.ProjectType}/{entity.Value}.txt"
				);
				var fileContent = File.ReadAllText(templateFilePath)
					.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

				ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
			}
		}

		public void GenerateFactoryFile(ProjectModel project)
		{
			var folderName = "factories";
			var filePrefix = "Factory";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				$"Factory/{project.ProjectType}/{project.ProjectCategory}.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}

		public void GenerateInterfaceFile(ProjectModel project)
		{
			var folderName = $"models/interfaces/{project.CamelCaseProjectName}";
			var filePrefix = "";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				$"Interfaces/{project.ProjectCategory}.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, true);
		}

		public void GenerateRepositoryFile(ProjectModel project) =>
			throw new NotImplementedException();

		public void GenerateServiceFile(ProjectModel project) =>
			throw new NotImplementedException();

		public void GenerateStrategyFile(ProjectModel project) =>
			throw new NotImplementedException();
	}
}
