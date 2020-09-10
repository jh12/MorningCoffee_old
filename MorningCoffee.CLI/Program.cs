using System.Threading.Tasks;

namespace MorningCoffee.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using MorningCoffee morningCoffee = new MorningCoffee();

            await morningCoffee.DoRoutinesAsync();
        }
    }
}
