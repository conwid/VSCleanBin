using System.Collections.Generic;
using EnvDTE;

namespace CleanBinCommands.Services
{
    public interface IProjectFolderSerivce
    {
        Project GetActiveProject();
        string GetProjectRootFolder(Project project);
        List<Project> GetSolutionProjects();
        string GetSolutionRootFolder();
        void GetSolutionFolderProjects(Project solutionFolder, List<Project> total);
    }
}