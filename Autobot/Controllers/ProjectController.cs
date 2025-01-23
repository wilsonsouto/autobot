using Autobot.Models;
using Spectre.Console;
using Autobot.Enums;

namespace Autobot.Controllers
{
	public interface IProjectController
	{
		ProjectModel GetUserInput();

		void AddConnectionFile(ProjectModel project);

		void AddConfigurationFile(ProjectModel project);

		void AddEntitiesFile(ProjectModel project);

		void AddFactoryFile(ProjectModel project);

		void AddInterfaceFile(ProjectModel project);

		void AddRepositoryFile(ProjectModel project);

		void AddServiceFile(ProjectModel project);

		void AddStrategyFile(ProjectModel project);
	}

	public class ProjectController : IProjectController
	{
		public ProjectModel GetUserInput()
		{
			while (true)
			{
				Console.Write("Nome do cliente: ");
				var clientName = Console.ReadLine() ?? "";

				var projectType = AnsiConsole.Prompt(
					new SelectionPrompt<ProjectType>()
						.Title("Selecione o tipo: ")
						.AddChoices(ProjectType.Deterministico, ProjectType.Generativo)
				);

				var projectCategory = projectType == ProjectType.Deterministico
					? AnsiConsole.Prompt(
						new SelectionPrompt<ProjectCategory>()
							.Title("Selecione a categoria: ")
							.AddChoices(
								ProjectCategory.Aquisicao,
								ProjectCategory.Localizador,
								ProjectCategory.Negociador,
								ProjectCategory.Psat
							)
					)
					: AnsiConsole.Prompt(
						new SelectionPrompt<ProjectCategory>()
							.Title("Selecione a categoria: ")
							.AddChoices(ProjectCategory.Whatsapp)
					);
				Console.Write("Nome do projeto Rogue: ");
				var rogueProjectName = Console.ReadLine() ?? "";

				return new ProjectModel(clientName, projectType, projectCategory, rogueProjectName);
			}
		}

		public void AddConfigurationFile(ProjectModel project) { }

		public void AddConnectionFile(ProjectModel project) { }

		public void AddEntitiesFile(ProjectModel project) { }

		public void AddFactoryFile(ProjectModel project) { }

		public void AddInterfaceFile(ProjectModel project) { }

		public void AddRepositoryFile(ProjectModel project) { }

		public void AddServiceFile(ProjectModel project) { }

		public void AddStrategyFile(ProjectModel project) { }
	}

}
