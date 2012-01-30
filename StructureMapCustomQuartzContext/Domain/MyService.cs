using System.Diagnostics;

namespace StructureMapCustomQuartzContext.Domain
{
    public interface IMyService
    {
        void Execute();
    }
    public class MyService : IMyService
    {
        private readonly IUnitOfWork unitOfWork;

        public MyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Execute()
        {
            var counter = unitOfWork.Counter.ToString();
            Trace.WriteLine(string.Format("Current UnitOfWork instance counter : {0}"
                ,counter));

            unitOfWork.IncrementCounter();
        }
    }
}