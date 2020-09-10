using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MorningCoffee.Shared.Routines;

namespace MorningCoffee
{
    public class MorningCoffee : IDisposable
    {
        private readonly IContainer _container;

        public MorningCoffee()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<MorningCoffeeModule>();

            _container = builder.Build();
        }

        public async Task DoRoutinesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<IRoutine> routines = _container.Resolve<IEnumerable<IRoutine>>();

            foreach (IRoutine routine in routines)
            {
                await routine.DoAsync(cancellationToken);
            }
        }


        public void Dispose()
        {
            _container.Dispose();
        }
    }
}