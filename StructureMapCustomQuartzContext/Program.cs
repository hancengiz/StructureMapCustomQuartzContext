using System;
using System.Windows.Forms;
using StructureMap;
using StructureMapCustomQuartzContext.IoCRegistry;

namespace StructureMapCustomQuartzContext
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StructureMapBootstrapper.Bootstrap();

            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}