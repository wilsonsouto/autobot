using Spectre.Console;
using Autobot.Enums;
using Autobot.Helpers;
using Autobot.Models;

namespace Autobot.Services
{
    public interface IProjectService
    {
        ProjectModel GetUserInput();

        void ConnectionFile(ProjectModel project);

        void ConfigurationFile(ProjectModel project);

        void EntitiesFile(ProjectModel project);

        void FactoryFile(ProjectModel project);

        void InterfaceFile(ProjectModel project);

        void RepositoryFile(ProjectModel project);

        void ServiceFile(ProjectModel project);

        void StrategyFile(ProjectModel project);
    }

    public class ProjectService : IProjectService
    {
        public ProjectModel GetUserInput()
        {
            while (true)
            {
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

                var projectCategory = projectType == ProjectType.Deterministico
                    ? AnsiConsole.Prompt(
                        new SelectionPrompt<ProjectCategory>()
                            .Title("Selecione a categoria do bot: ")
                            .AddChoices(
                                ProjectCategory.Aquisicao,
                                ProjectCategory.Localizador,
                                ProjectCategory.Negociador,
                                ProjectCategory.Preventivo,
                                ProjectCategory.Ura,
                                ProjectCategory.Psat
                            )
                    )
                    : AnsiConsole.Prompt(
                        new SelectionPrompt<ProjectCategory>()
                            .Title("Selecione a categoria do bot: ")
                            .AddChoices(
                                ProjectCategory.Negociador,
                                ProjectCategory.Whatsapp
                            )
                    );

                Console.Write("Nome do projeto Rogue: ");
                var rogueProjectName = Console.ReadLine();

                while (!ValidationHelper.IsStringValid(rogueProjectName))
                {
                    Console.Write("Insira o nome do projeto Rogue válido: ");
                    rogueProjectName = Console.ReadLine();
                }

                return new ProjectModel(clientName!, projectType, projectCategory, rogueProjectName!);
            }
        }

        public void ConfigurationFile(ProjectModel project)
        {
            var templatePath = Configuration.DataPath + "/ConfigurationFile.txt";
            var content = File.ReadAllText(templatePath);

            content = content
                           .Replace("{{databaseConnectionName}}", project.PascalCaseProjectName.ToUpper())
                           .Replace("{{camelCaseProjectName}}", project.CamelCaseProjectName);

            ProjectHelper.CreateAndWriteToFile("config", content, project);
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
