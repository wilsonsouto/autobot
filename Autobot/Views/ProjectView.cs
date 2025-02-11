using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;
using Spectre.Console;

namespace Autobot.Views
{
	public static class ProjectView
	{
		public static ProjectModel RunMenu()
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

					Console.Write("Nome do projeto Rogue: ");
					var rogueProjectName = Console.ReadLine();

					while (!ValidationHelper.IsStringValid(rogueProjectName))
					{
						Console.Write("Insira o nome do projeto Rogue válido: ");
						rogueProjectName = Console.ReadLine();
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

					if (projectCategory != ProjectCategory.Psat)
					{
						var projectClassification = AnsiConsole.Prompt(
							new SelectionPrompt<ProjectClassification>()
								.Title("Selecione a classificação do bot: ")
								.AddChoices(
									ProjectClassification.Aquisicao,
									ProjectClassification.Localizador,
									ProjectClassification.Negociador,
									ProjectClassification.Preventivo
								)
						);

						return new ProjectModel(
							clientName!,
							rogueProjectName!,
							projectType,
							projectCategory,
							projectClassification
						);
					}

					return new ProjectModel(
						clientName!,
						rogueProjectName!,
						projectType,
						projectCategory
					);
				}
			}
		}
	}
}