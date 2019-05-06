using CleanBinCommands.Services;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBinCommands.Commands
{
    public sealed class CleanSolutionCommand : CleanSolutionCommandBase
    {
        public CleanSolutionCommand(IProjectFolderSerivce projectFolderService, IErrorHandlerService errorHandlerService, IVsOutputPaneService vsOutputPaneService, OleMenuCommandService commandService) :
            base(projectFolderService, errorHandlerService, vsOutputPaneService, commandService, deletePackages: true, PackageGuids.guidCleanSolutionCommandPackageCmdSet, PackageIds.CleanSolutionCommandId)
        {
        }
    }
}
