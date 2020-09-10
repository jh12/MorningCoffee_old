using System.Threading.Tasks;
using MorningCoffee.Services;
using MorningCoffee.Shared.Services;

namespace MorningCoffee.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (MorningCoffee morningCoffee = new MorningCoffee())
            {
                await morningCoffee.DoRoutinesAsync();
            }
        }
    }
}
