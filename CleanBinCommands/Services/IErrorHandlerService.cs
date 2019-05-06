using System;

namespace CleanBinCommands.Services
{
    public interface IErrorHandlerService
    {
        void WriteErrorMessage(string message);
        void WriteErrorMessage(string message, Exception ex);        
    }
}