using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace CleanBinCommands.Services
{
    public class VsOutputPaneService : IVsOutputPaneService
    {
        private readonly IVsOutputWindowPane generalOutputWindowPane;
        public VsOutputPaneService(IVsOutputWindowPane generalOutputWindowPane)
        {
            this.generalOutputWindowPane = generalOutputWindowPane ?? throw new ArgumentNullException(nameof(generalOutputWindowPane));
        }
        public void WriteMessage(string message)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            this.generalOutputWindowPane.OutputStringThreadSafe("\r\n" + message);
        }
    }
}
