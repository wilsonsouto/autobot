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

					AnsiConsole.Write(new FigletText("Autobot").Color(Color.Blue));
					AnsiConsole.MarkupLine("[bold red]Atenção![/] Certifique-se de rodar '[green]git pull[/]' para obter as últimas atualizações antes de continuar.\n");

					Console.Write("Informe o nome do cliente (ex: Sem Parar, Anima): ");
					var clientName = Console.ReadLine();

					while (!ValidationHelper.IsStringValid(clientName))
					{
						Console.Write("Informe o nome de cliente válido: ");
						clientName = Console.ReadLine();
					}

					Console.Write("Informe o nome do projeto (valor do campo 'Project' no arquivo 'appsettings.json'): ");
					var projectName = Console.ReadLine();

					while (!ValidationHelper.IsStringValid(projectName))
					{
						Console.Write("Informe o nome do projeto válido: ");
						projectName = Console.ReadLine();
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
							projectName!,
							projectType,
							projectCategory,
							projectClassification
						);
					}

					return new ProjectModel(
						clientName!,
						projectName!,
						projectType,
						projectCategory
					);
				}
			}
		}
	}
}