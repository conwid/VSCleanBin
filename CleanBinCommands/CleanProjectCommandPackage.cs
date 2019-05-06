using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using CleanBinCommands.Commands;
using CleanBinCommands.Services;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using Task = System.Threading.Tasks.Task;

namespace CleanBinCommands
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidCleanCommandsPackageString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class CleanProjectCommandPackage : AsyncPackage
    {
        private IProjectFolderSerivce projectFolderService;
        private IErrorHandlerService errorHandlerService;
        public CleanProjectCommandPackage()
        {
        }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            projectFolderService = new ProjectFolderSerivce((DTE2)GetGlobalService(typeof(SDTE)));
            var vsOutputPane = (IVsOutputWindowPane)await GetServiceAsync(typeof(SVsGeneralOutputWindowPane));
            var vsOutputPaneService = new VsOutputPaneService(vsOutputPane);
            errorHandlerService = new ErrorHandlerService(vsOutputPaneService);
            OleMenuCommandService commandService = await this.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            new CleanSolutionCommand(projectFolderService, errorHandlerService, vsOutputPaneService, commandService);
            new CleanSolutionWithoutPackagesCommand(projectFolderService, errorHandlerService, vsOutputPaneService, commandService);
            new CleanProjectCommand(projectFolderService, errorHandlerService, vsOutputPaneService, commandService);
        }
    }
}
