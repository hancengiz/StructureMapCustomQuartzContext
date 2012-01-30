using System;
using Quartz;
using StructureMap.Pipeline;

namespace StructureMapCustomQuartzContext.QuartzLifecycleContext
{
    public abstract class BaseJob : IJob
    {
        [ThreadStatic]
        private static IObjectCache objectCache;

        protected static void RegisterANewCache()
        {
            objectCache = new MainObjectCache();
        }

        public static IObjectCache Cache
        {
            get
            {
                return objectCache;
            }
        }

        public void Execute(JobExecutionContext context)
        {
            RegisterANewCache();
            ExecuteJob(context);
        }

        protected abstract void ExecuteJob(JobExecutionContext context);

    }
}