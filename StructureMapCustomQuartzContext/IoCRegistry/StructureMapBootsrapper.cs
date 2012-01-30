using StructureMap;

namespace StructureMapCustomQuartzContext.IoCRegistry
{
    public class StructureMapBootstrapper : IBootstrapper
    {
        #region IBootstrapper Members

        public virtual void BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x =>
                x.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.AssemblyContainingType<WindowsServiceRegistry>();
                    scanner.LookForRegistries();
                }));
        }

        #endregion

        public static void Bootstrap()
        {
            new StructureMapBootstrapper().BootstrapStructureMap();
        }
    }
}