using System.Threading.Tasks;

namespace MorningCoffee.Shared.Services
{
    public interface IProcessService
    {
        Task<bool> IsRunning(string processName);
        Task StartProcess(string fileNameOrPath, string? arguments = null);
    }
}