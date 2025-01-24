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
			var databaseConnectionName =
			$"{project.DatabaseConnectionName}_{project.ProjectType}_{project.ProjectCategory}".ToUpper();
			
			var templatePath = Configuration.DataPath + "/ConfigurationFile.txt";
			var content = File.ReadAllText(templatePath);

			content = content
						   .Replace("{{databaseConnectionName}}", databaseConnectionName)
						   .Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);


			ProjectHelper.CreateAndWriteToFile("config", "Config", content, project);
		}

		public void ConnectionFile(ProjectModel project) => throw new NotImplementedException();

		public void EntitiesFile(ProjectModel project) => throw new NotImplementedException();

		public void FactoryFile(ProjectModel project) => throw new NotImplementedException();

		public void InterfaceFile(ProjectModel project) => throw new NotImplementedException();

		public void RepositoryFile(ProjectModel project) => throw new NotImplementedException();

		public void ServiceFile(ProjectModel project) => throw new NotImplementedException();

		public void StrategyFile(ProjectModel project) => throw new NotImplementedException();
	}

}
