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
    public sealed class CleanProjectCommand : CleanCommandBase
    {                
        public CleanProjectCommand(IProjectFolderSerivce projectFolderService, IErrorHandlerService errorHandlerService, OleMenuCommandService commandService):
            base(projectFolderService, errorHandlerService, commandService, PackageGuids.guidCleanProjectCommandPackageCmdSet, PackageIds.CleanProjectCommandId)
        {                      
        }

        protected override void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();            

            var projectRootFolder = projectFolderService.GetProjectRootFolder(projectFolderService.GetActiveProject());
            if (projectRootFolder == null)
                return;

            SafeDelete(Path.Combine(projectRootFolder, "bin"));
            SafeDelete(Path.Combine(projectRootFolder, "obj"));            

        }
    }
}
