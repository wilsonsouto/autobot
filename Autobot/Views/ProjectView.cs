using Autobot.Enums;
using Spectre.Console;

namespace Autobot.Views
{
    internal class ProjectView
    {
        internal static void RunMenu()
        {
            while (true)
            {
                Console.Write("Nome do cliente: ");
                var clientName = Console.ReadLine();

                var projectType = AnsiConsole.Prompt(
                    new SelectionPrompt<ProjectType>()
                        .Title("Selecione o tipo: ")
                        .AddChoices(ProjectType.Deterministico, ProjectType.Generativo)
                );

                ProjectCategory projectCategory;

                if (projectType == ProjectType.Deterministico)
                {
                    projectCategory = AnsiConsole.Prompt(
                        new SelectionPrompt<ProjectCategory>()
                            .Title("Selecione a categoria: ")
                            .AddChoices(
                                ProjectCategory.Aquisicao,
                                ProjectCategory.Localizador,
                                ProjectCategory.Negociador,
                                ProjectCategory.Psat
                            )
                    );
                }
                else
                {
                    projectCategory = AnsiConsole.Prompt(
                        new SelectionPrompt<ProjectCategory>()
                            .Title("Selecione a categoria: ")
                            .AddChoices(ProjectCategory.Whatsapp)
                    );
                }

                Console.Write("Nome do projeto Rogue: ");
                var rogueProjectName = Console.ReadLine();

                Console.WriteLine(
                    $"{clientName}, {projectType}, {projectCategory}, {rogueProjectName}"
                );
                break;
            }
        }
    }
}
