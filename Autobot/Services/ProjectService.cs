using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;

namespace Autobot.Services
{
	public class ProjectService : IProjectService
	{
		public void GenerateConfigurationFile(ProjectModel project)
		{
			const string folderName = "config";
			const string filePrefix = "Config";

			var connectionName = $"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectCategory}".ToUpper();

			if (project.ProjectCategory != ProjectCategory.Psat)
				connectionName = $"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectClassification}_{project.ProjectCategory}".ToUpper();

			var templateFilePath = Path.Combine(Configuration.DataPath, "Config/Config.txt");
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{databaseConnectionName}}", connectionName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}

		public void GenerateConnectionFile(ProjectModel project)
		{
			const string folderName = "database/connections";
			const string filePrefix = "Connection";

			var templateFilePath = Path.Combine(Configuration.DataPath, "Connection/Connection.txt");
			var fileContent = File.ReadAllText(templateFilePath).Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

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
				{ 6, "Tabulacao" }
			};

			if (project.ProjectCategory != ProjectCategory.Psat)
				entitiesDictionary.Remove(5);

			foreach (KeyValuePair<int, string> entity in entitiesDictionary)
			{
				var folderName = $"models/entities/{project.CamelCaseProjectName}";
				var filePrefix = entity.Value;

				var templateFilePath = Path.Combine(Configuration.DataPath, $"Entities/{project.ProjectType}/{entity.Value}.txt");
				var fileContent = File.ReadAllText(templateFilePath).Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

				ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
			}
		}

		public void GenerateFactoryFile(ProjectModel project)
		{
			const string folderName = "factories";
			const string filePrefix = "Factory";

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
			const string filePrefix = "";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				$"Interfaces/{project.ProjectCategory}.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath);

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, true);
		}

		public void GenerateRepositoryFile(ProjectModel project)
		{
			var entitiesDictionary = new Dictionary<int, string>
			{
				{ 1, "AtendimentoRepository" },
				{ 2, "EventoRepository" },
				{ 3, "NocApiStatusRepository" },
				{ 4, "OlosStatusRepository" },
				{ 5, "SurveyRepository" },
				{ 6, "TabulacaoRepository" }
			};

			if (project.ProjectCategory != ProjectCategory.Psat)
				entitiesDictionary.Remove(5);

			foreach (KeyValuePair<int, string> entity in entitiesDictionary)
			{
				var folderName = $"repositories/{project.CamelCaseProjectName}";
				var filePrefix = entity.Value;

				var templateFilePath = Path.Combine(
					Configuration.DataPath,
					$"Repositories/{entity.Value}.txt"
				);
				var fileContent = File.ReadAllText(templateFilePath)
					.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName)
					.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);
				;

				ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
			}
		}

		public void GenerateServiceFile(ProjectModel project)
		{
			const string folderName = "services";
			const string filePrefix = "Service";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				$"Services/{project.ProjectCategory}.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);
			;

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}

		public void GenerateStrategyFile(ProjectModel project)
		{
			const string folderName = "strategies";
			const string filePrefix = "Strategy";

			var templateFilePath = Path.Combine(
				Configuration.DataPath,
				$"Strategy/{project.ProjectType}/{project.ProjectCategory}.txt"
			);
			var fileContent = File.ReadAllText(templateFilePath)
				.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName)
				.Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName)
				.Replace("{{rogueProjectName}}", project.RogueProjectName);
			;

			ProjectHelper.CreateAndWriteToFile(folderName, filePrefix, fileContent, project, false);
		}
	}
}