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
			var subFolderPath = "config";
			var filePrefix = "Config";
			var databaseConnectionName =
			$"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectCategory}".ToUpper();

			var templatePath = Configuration.DataPath + "/Config.txt";
			var fileContent = File.ReadAllText(templatePath);

			fileContent = fileContent
						   .Replace("{{databaseConnectionName}}", databaseConnectionName)
						   .Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);


			ProjectHelper.CreateAndWriteToFile(subFolderPath, filePrefix, fileContent, project);
		}

		public void ConnectionFile(ProjectModel project)
		{
			var subFolderPath = "database/connections";
			var filePrefix = "Connection";
			var templatePath = Configuration.DataPath + "/Connection.txt";
			var fileContent = File.ReadAllText(templatePath);

			fileContent = fileContent.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

			ProjectHelper.CreateAndWriteToFile(subFolderPath, filePrefix, fileContent, project);
		}

		public void EntitiesFile(ProjectModel project)
		{
			List<string> EntitiesList =
			[
				"Atendimento",
				"Evento",
				"NocApiStatus",
				"OlosStatus",
				"Tabulacao",
			];

			var projectTypeFolder = project.ProjectType == Enums.ProjectType.Deterministico ?
			"Deterministico" : "Generativo";

			foreach (var entitie in EntitiesList)
			{
				var subFolderPath = $"models/entities/{project.CamelCaseProjectName}";
				var templatePath = Configuration.DataPath + $"/Entities/{projectTypeFolder}/{entitie}.txt";
				var fileContent = File.ReadAllText(templatePath);

				fileContent = fileContent.Replace("{{pascalCaseProjectName}}", project.PascalCaseProjectName);

				ProjectHelper.CreateAndWriteToFile(subFolderPath, entitie, fileContent, project);
			}
		}

		public void FactoryFile(ProjectModel project) => throw new NotImplementedException();

		public void InterfaceFile(ProjectModel project) => throw new NotImplementedException();

		public void RepositoryFile(ProjectModel project) => throw new NotImplementedException();

		public void ServiceFile(ProjectModel project) => throw new NotImplementedException();

		public void StrategyFile(ProjectModel project) => throw new NotImplementedException();
	}

}
