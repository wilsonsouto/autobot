using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;
using Spectre.Console;

namespace Autobot.Views
{
	internal class ProjectView
	{
		internal static ProjectModel RunMenu()
		{
			{
				while (true)
				{
					Console.Clear();

					Console.Write("Nome do cliente: ");
					var clientName = Console.ReadLine();

					while (!ValidationHelper.IsStringValid(clientName))
					{
						Console.Write("Insira o nome de cliente válido: ");
						clientName = Console.ReadLine();
					}

					var projectType = AnsiConsole.Prompt(
						new SelectionPrompt<ProjectType>()
							.Title("Selecione o tipo do bot: ")
							.AddChoices(ProjectType.Deterministico, ProjectType.Generativo)
					);

					var projectCategory =
						projectType == ProjectType.Deterministico
							? AnsiConsole.Prompt(
								new SelectionPrompt<ProjectCategory>()
									.Title("Selecione a categoria do bot: ")
									.AddChoices(ProjectCategory.Vda, ProjectCategory.Psat)
							)
							: AnsiConsole.Prompt(
								new SelectionPrompt<ProjectCategory>()
									.Title("Selecione a categoria do bot: ")
									.AddChoices(ProjectCategory.Vda, ProjectCategory.Wpp)
							);

					Console.Write("Nome do projeto Rogue: ");
					var rogueProjectName = Console.ReadLine();

					while (!ValidationHelper.IsStringValid(rogueProjectName))
					{
						Console.Write("Insira o nome do projeto Rogue válido: ");
						rogueProjectName = Console.ReadLine();
					}

					return new ProjectModel(
						clientName!,
						projectType,
						projectCategory,
						rogueProjectName!
					);
				}
			}
		}
	}
}
