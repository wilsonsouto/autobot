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
}