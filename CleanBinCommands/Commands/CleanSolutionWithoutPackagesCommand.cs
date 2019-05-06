using CleanBinCommands.Services;
using Microsoft.VisualStudio.Shell;

namespace CleanBinCommands.Commands
{
    public sealed class CleanSolutionWithoutPackagesCommand : CleanSolutionCommandBase
    {
        public CleanSolutionWithoutPackagesCommand(IProjectFolderSerivce projectFolderService, IErrorHandlerService errorHandlerService, IVsOutputPaneService vsOutputPaneService, OleMenuCommandService commandService) :
            base(projectFolderService, errorHandlerService, vsOutputPaneService, commandService, deletePackages: false, PackageGuids.guidCleanSolutionWithoutPackagesCommandPackageCmdSet, PackageIds.CleanSolutionWithoutPackagesCommandId)
        {
        }
    }
}
