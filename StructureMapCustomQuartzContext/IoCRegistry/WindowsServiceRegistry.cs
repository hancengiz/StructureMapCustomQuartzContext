using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMapCustomQuartzContext.Domain;
using StructureMapCustomQuartzContext.Jobs;
using StructureMapCustomQuartzContext.QuartzLifecycleContext;

namespace StructureMapCustomQuartzContext.IoCRegistry
{
    public class WindowsServiceRegistry : Registry
    {
        public WindowsServiceRegistry()
        {
            Scan(scanner =>
                     {
                         scanner.TheCallingAssembly();
                         scanner.WithDefaultConventions();
                     });

            For<IJobFactory>().Use<StructureMapSchedularJobFactory>();
            For<ISchedulerFactory>().Use(ctx => new StdSchedulerFactory());
            For<IScheduler>().Use(delegate(IContext ctx)
            {
                var scheduler = ctx.GetInstance<ISchedulerFactory>().GetScheduler();
                scheduler.JobFactory = ctx.GetInstance<IJobFactory>();
                return scheduler;
            });

            //For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();

            For<IUnitOfWork>().LifecycleIs(new HybridHttpQuartzLifecycle()).Use<UnitOfWork>(); 

        }
    }
}