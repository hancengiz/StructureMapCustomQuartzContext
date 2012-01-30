using StructureMap.Pipeline;

namespace StructureMapCustomQuartzContext.QuartzLifecycleContext
{
    public class QuartzLifecycle : ILifecycle
    {
        public void EjectAll()
        {
            FindCache().DisposeAndClear();
        }

        public IObjectCache FindCache()
        {
            return BaseJob.Cache;
        }

        public string Scope { get { return "QuartzLifecycle"; } }
    }
}
