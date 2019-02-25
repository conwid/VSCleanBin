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
        protected CleanCommandBase(IProjectFolderSerivce projectFolderService,
                                   IErrorHandlerService errorHandlerService,
                                   OleMenuCommandService commandService, Guid guidPackageCmdSet, int commandId)
        {
            if (commandService == null)
                throw new ArgumentNullException(nameof(commandService));
            this.projectFolderService = projectFolderService ?? throw new ArgumentNullException(nameof(projectFolderService));
            this.errorHandlerService = errorHandlerService ?? throw new ArgumentNullException(nameof(errorHandlerService));
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
                errorHandlerService.WriteMessage($"Folder {folder} deleted");
            }
            catch (Exception ex)
            {
                errorHandlerService.WriteErrorMessage($"Could not delete folder {folder}", ex);
            }
        }
    }
}