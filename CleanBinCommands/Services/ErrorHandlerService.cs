using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBinCommands.Services
{
    public class ErrorHandlerService : IErrorHandlerService
    {
        private readonly IVsOutputPaneService vsOutputPaneService;
        public ErrorHandlerService(IVsOutputPaneService vsOutputPaneService)
        {
            this.vsOutputPaneService = vsOutputPaneService ?? throw new ArgumentNullException(nameof(vsOutputPaneService));
        }

        public void WriteErrorMessage(string message, Exception ex) => vsOutputPaneService.WriteMessage($"Error: {message}; {ex}");
        public void WriteErrorMessage(string message) => vsOutputPaneService.WriteMessage($"Error: {message}");       
    }
}
