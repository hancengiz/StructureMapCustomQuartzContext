namespace StructureMapCustomQuartzContext.Domain
{
    public interface IUnitOfWork
    {
        long Counter { get; }
        void IncrementCounter();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public long Counter { get; private set; }
        public void IncrementCounter()
        {
            Counter += 1;
        }
    }
}