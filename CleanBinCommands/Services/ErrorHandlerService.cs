using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBinCommands.Services
{
    public class ErrorHandlerService : IErrorHandlerService
    {
        private readonly IVsOutputWindowPane generalOutputWindowPane;

        public ErrorHandlerService(IVsOutputWindowPane generalOutputWindowPane)
        {
            this.generalOutputWindowPane = generalOutputWindowPane ?? throw new ArgumentNullException(nameof(generalOutputWindowPane));
        }

        public void WriteErrorMessage(string message, Exception ex) => WriteMessage($"Error: {message}; {ex}");
        public void WriteErrorMessage(string message) => WriteMessage($"Error: {message}");

        public void WriteMessage(string message)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            this.generalOutputWindowPane.OutputStringThreadSafe(message);
        }
    }
}
