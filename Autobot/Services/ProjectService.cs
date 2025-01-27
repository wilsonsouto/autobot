using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;

namespace Autobot.Services
{
	public interface IProjectService
	{
		void ConfigurationFile(ProjectModel project);

		void ConnectionFile(ProjectModel project);

		void EntitiesFile(ProjectModel project);

		void FactoryFile(ProjectModel project);

		void InterfaceFile(ProjectModel project);

		void RepositoryFile(ProjectModel project);

		void ServiceFile(ProjectModel project);

		void StrategyFile(ProjectModel project);
	}

	public class ProjectService : IProjectService
	{
		public void ConfigurationFile(ProjectModel project)
		{
			var folderName = "config";
			var filePrefix = "Config";

			var connectionName =
				$"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectCategory}".ToUpper();

			var templateFilePath = Path.Combine(Configuration.DataPath, "Config/Config.txt");
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{databaseConnectionName}}", connectionName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project);
		}

		public void ConnectionFile(ProjectModel project)
		{
			var folderName = "database/connections";
			var filePrefix = "Connection";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				"Connection/Connection.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project);
		}

		public void EntitiesFile(ProjectModel project)
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

				ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project);
			}
		}

		public void FactoryFile(ProjectModel project)
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

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project);
		}

		public void InterfaceFile(ProjectModel project) => throw new NotImplementedException();

		public void RepositoryFile(ProjectModel project) => throw new NotImplementedException();

		public void ServiceFile(ProjectModel project) => throw new NotImplementedException();

		public void StrategyFile(ProjectModel project) => throw new NotImplementedException();
	}
}
