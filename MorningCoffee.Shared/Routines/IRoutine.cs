using System.Threading;
using System.Threading.Tasks;

namespace MorningCoffee.Shared.Routines
{
    public interface IRoutine
    {
        Task DoAsync(CancellationToken cancellationToken);
    }
}