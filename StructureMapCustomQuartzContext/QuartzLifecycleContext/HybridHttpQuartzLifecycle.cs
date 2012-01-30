using StructureMap.Pipeline;

namespace StructureMapCustomQuartzContext.QuartzLifecycleContext
{
    public class HybridHttpQuartzLifecycle : HttpLifecycleBase<HttpContextLifecycle, QuartzLifecycle>
    {
        public override string Scope { get { return "HybridHttpQuartzLifecycle"; } }
    }
}