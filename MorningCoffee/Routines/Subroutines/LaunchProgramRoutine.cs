using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MorningCoffee.Shared.Configuration;
using MorningCoffee.Shared.Routines;
using MorningCoffee.Shared.Services;

namespace MorningCoffee.Routines.Subroutines
{
    public class LaunchProgramRoutine : IRoutine
    {
        private readonly IProcessService _processService;
        private readonly LaunchProgramRoutineConfiguration? _routineConfiguration;

        public LaunchProgramRoutine(IConfiguration configuration, IProcessService processService)
        {
            _routineConfiguration = configuration.GetSection("routines:programs").Get<LaunchProgramRoutineConfiguration>();

            _processService = processService;
        }

        public async Task DoAsync(CancellationToken cancellationToken)
        {
            if (_routineConfiguration?.Processes == null)
                return;

            foreach (ProcessDefinition definition in _routineConfiguration.Processes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                await _processService.StartProcess(definition.FileNameOrPath, definition.Arguments);
            }
        }
    }
}