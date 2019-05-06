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
  
    
    public class CleanSolutionCommandBase : CleanCommandBase
    {
        private readonly bool deletePackages;
        public CleanSolutionCommandBase(IProjectFolderSerivce projectFolderService, 
                                        IErrorHandlerService errorHandlerService,
                                        IVsOutputPaneService vsOutputPaneService,
                                        OleMenuCommandService commandService,
                                        bool deletePackages,
                                        Guid packageCmdSet,
                                        int commandId) : 
            base(projectFolderService, errorHandlerService, vsOutputPaneService, commandService, packageCmdSet, commandId)
        {
            this.deletePackages = deletePackages;
        }       

        protected override void Execute(object sender, EventArgs e)
        {
            DeleteFolders();
        }

        private void DeleteFolders()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (deletePackages)
            {
                var solutionRootFolder = projectFolderService.GetSolutionRootFolder();
                if (solutionRootFolder != null)
                    SafeDelete(Path.Combine(solutionRootFolder, "packages"));
            }

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
