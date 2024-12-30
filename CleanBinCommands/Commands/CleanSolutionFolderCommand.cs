using CleanBinCommands.Services;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBinCommands.Commands
{
    public sealed class CleanSolutionFolderCommand : CleanCommandBase
    {
        public CleanSolutionFolderCommand(IProjectFolderSerivce projectFolderService, IErrorHandlerService errorHandlerService, IVsOutputPaneService vsOutputPaneService, OleMenuCommandService commandService) :
            base(projectFolderService, errorHandlerService, vsOutputPaneService, commandService, PackageGuids.guidCleanSolutionFolderCommandPackageCmdSet, PackageIds.CleanSolutionFolderCommandId)
        {

        }

        protected override void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            List<EnvDTE.Project> projects = new List<EnvDTE.Project>();
            projectFolderService.GetSolutionFolderProjects(projectFolderService.GetActiveProject(), projects);

            foreach (EnvDTE.Project project in projects)
            {
                var projectRootFolder = projectFolderService.GetProjectRootFolder(project);
                if (projectRootFolder == null)
                    continue;

                SafeDelete(Path.Combine(projectRootFolder, "bin"));
                SafeDelete(Path.Combine(projectRootFolder, "obj"));
            }
        }
    }
}
