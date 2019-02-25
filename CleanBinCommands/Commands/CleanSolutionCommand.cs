using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CleanBinCommands.Services;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace CleanBinCommands.Commands
{
    public sealed class CleanSolutionCommand : CleanCommandBase
    {                        
        public CleanSolutionCommand(IProjectFolderSerivce projectFolderService, IErrorHandlerService errorHandlerService, OleMenuCommandService commandService) : 
            base(projectFolderService, errorHandlerService, commandService, PackageGuids.guidCleanSolutionCommandPackageCmdSet, PackageIds.CleanSolutionCommandId)
        {                      
        }       

        protected override void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var solutionRootFolder = projectFolderService.GetSolutionRootFolder();
            if (solutionRootFolder != null)
                SafeDelete(Path.Combine(solutionRootFolder, "packages"));

            foreach (EnvDTE.Project project in projectFolderService.GetSolutionProjects())
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
