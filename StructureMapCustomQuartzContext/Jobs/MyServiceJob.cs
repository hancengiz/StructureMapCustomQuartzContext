using Quartz;
using StructureMap;
using StructureMapCustomQuartzContext.Domain;
using StructureMapCustomQuartzContext.QuartzLifecycleContext;

namespace StructureMapCustomQuartzContext.Jobs
{
    //public class MyServiceJob : IJob
    //{
    //    private readonly IMyService myService;

    //    public MyServiceJob(IMyService myService)
    //    {
    //        this.myService = myService;
    //    }

    //    public void Execute(JobExecutionContext context)
    //    {
    //        myService.Execute();
    //    }
    //}

    public class MyServiceJob : BaseJob
    {
        private IMyService myService;

        protected override void ExecuteJob(JobExecutionContext context)
        {
            myService = ObjectFactory.GetInstance<IMyService>();
            myService.Execute();
        }
    }
}
