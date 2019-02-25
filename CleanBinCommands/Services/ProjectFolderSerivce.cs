using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanBinCommands.Services
{
    public class ProjectFolderSerivce : IProjectFolderSerivce
    {
        private const string CannotGetCurrentProjectExceptionMessage = "Cannot get current project";
        private const string FullPathProperty = "FullPath";
        private DTE2 dte;

        public ProjectFolderSerivce(DTE2 dte)
        {
            this.dte = dte;
        }

        public List<Project> GetSolutionProjects() => dte.Solution.Projects.Cast<Project>()
                                                         .Where(p => SafeIsNotNullOrEmpty(p))
                                                         .ToList();

        private bool SafeIsNotNullOrEmpty(Project p)
        {
            try
            {
                return !string.IsNullOrEmpty(p.FullName);
            }
            catch
            {
                return false;
            }
        }

        public Project GetActiveProject()
        {
            if (dte.ActiveSolutionProjects is Array activeSolutionProjects && activeSolutionProjects.Length > 0)
            {
                return activeSolutionProjects.GetValue(0) as Project;
            }

            var doc = dte.ActiveDocument;
            if (doc != null && !string.IsNullOrEmpty(doc.FullName))
            {
                return dte.Solution?.FindProjectItem(doc.FullName)?.ContainingProject ?? throw new Exception(CannotGetCurrentProjectExceptionMessage);
            }

            throw new Exception(CannotGetCurrentProjectExceptionMessage);
        }

        public string GetProjectRootFolder(Project project)
        {
            if (string.IsNullOrEmpty(project.FullName))
                return null;

            string fullPath = project.Properties.Item(FullPathProperty).Value as string;

            if (string.IsNullOrEmpty(fullPath))
                return File.Exists(project.FullName) ? Path.GetDirectoryName(project.FullName) : null;

            if (Directory.Exists(fullPath))
                return fullPath;

            if (File.Exists(fullPath))
                return Path.GetDirectoryName(fullPath);

            return null;
        }

        public string GetSolutionRootFolder()
        {
            if (string.IsNullOrEmpty(dte.Solution.FullName))
                return null;
            return File.Exists(dte.Solution.FullName) ? Path.GetDirectoryName(dte.Solution.FullName) : null;
        }
    }
}
