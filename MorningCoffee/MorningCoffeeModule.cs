using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using MorningCoffee.Services;
using MorningCoffee.Shared.Routines;
using MorningCoffee.Shared.Services;
using Module = Autofac.Module;

namespace MorningCoffee
{
    public class MorningCoffeeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConfiguration(builder);
            RegisterRoutines(builder);

            builder.RegisterType<ProcessService>().As<IProcessService>();
        }

        private void RegisterRoutines(ContainerBuilder builder)
        {
            Assembly[] assemblies = new List<Assembly>{
                typeof(MorningCoffee).Assembly,
                typeof(IRoutine).Assembly,
                Assembly.GetEntryAssembly()
            }.Distinct().ToArray();

            builder.RegisterAssemblyTypes(assemblies).Where(t => t.IsAssignableTo<IRoutine>()).As<IRoutine>();
        }

        private void RegisterConfiguration(ContainerBuilder builder)
        {
            //TODO: Implement writable configuration like: https://stackoverflow.com/a/45986656/

            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            builder.Register(f => configurationRoot).As<IConfiguration>().SingleInstance();
        }
    }
}