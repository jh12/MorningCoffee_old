using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MorningCoffee.Shared.Exceptions;
using MorningCoffee.Shared.Services;

namespace MorningCoffee.Services
{
    public class ProcessService : IProcessService
    {
        public Task<bool> IsRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            return Task.FromResult(processes.Any());
        }

        public Task StartProcess(string fileNameOrPath, string? arguments)
        {
            using Process process = new Process();

            process.StartInfo.FileName = fileNameOrPath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;

            bool isStarted;

            try
            {
                isStarted = process.Start();
            }
            catch (InvalidOperationException e)
            {
                throw new ProcessNotFoundException(fileNameOrPath, e.Message, e);
            }
            catch (Win32Exception e)
            {
                throw new ProcessStartException(fileNameOrPath, e.Message, e);
            }

            if(!isStarted)
                throw new ProcessStartException(fileNameOrPath);

            return Task.CompletedTask;
        }
    }
}