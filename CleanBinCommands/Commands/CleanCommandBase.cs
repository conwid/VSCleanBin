using System;
using System.ComponentModel.Design;
using System.IO;
using CleanBinCommands.Services;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace CleanBinCommands.Commands
{
    public abstract class CleanCommandBase
    {
        protected readonly IProjectFolderSerivce projectFolderService;
        protected readonly IErrorHandlerService errorHandlerService;
        private readonly IVsOutputPaneService vsOutputPaneService;
        protected CleanCommandBase(IProjectFolderSerivce projectFolderService,
                                   IErrorHandlerService errorHandlerService,
                                   IVsOutputPaneService vsOutputPaneService,
                                   OleMenuCommandService commandService, Guid guidPackageCmdSet, int commandId)
        {
            if (commandService == null)
                throw new ArgumentNullException(nameof(commandService));
            this.projectFolderService = projectFolderService ?? throw new ArgumentNullException(nameof(projectFolderService));
            this.errorHandlerService = errorHandlerService ?? throw new ArgumentNullException(nameof(errorHandlerService));
            this.vsOutputPaneService = vsOutputPaneService ?? throw new ArgumentNullException(nameof(vsOutputPaneService));
            var menuCommandID = new CommandID(guidPackageCmdSet, commandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        protected abstract void Execute(object sender, EventArgs e);
        protected void SafeDelete(string folder)
        {
            if (!Directory.Exists(folder))
                return;

            try
            {
                Directory.Delete(folder, true);
                vsOutputPaneService.WriteMessage($"Folder {folder} deleted");
            }
            catch (Exception ex)
            {
                errorHandlerService.WriteErrorMessage($"Could not delete folder {folder}", ex);
            }
        }
    }
}