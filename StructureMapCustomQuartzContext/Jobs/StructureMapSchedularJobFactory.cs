using System;
using Quartz;
using Quartz.Spi;
using StructureMap;

namespace StructureMapCustomQuartzContext.Jobs
{
    /// <summary>
    /// Custom JobFactory for creating Job instances with StructuremapIoC
    /// </summary>
    public class StructureMapSchedularJobFactory : IJobFactory
    {
        readonly IContainer container;

        public StructureMapSchedularJobFactory(IContainer container)
        {
            this.container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle)
        {
            try
            {
                var jobDetail = bundle.JobDetail;
                var jobType = jobDetail.JobType;
                return (IJob)container.GetInstance(jobType);
            }
            catch (Exception e)
            {
                var se = new SchedulerException("Problem instantiating class", e);
                throw se;
            }
        }
    }
}