using System;
using System.Threading;
using AOPSampleApp.Aspects;

namespace AOPSampleApp.NightBuild
{
    public sealed class LongRunningProcess
    {
        [LogAspect]
        [TimingAspect]
        public void DoSomeLongRunningTask()
        {
            Console.WriteLine("");
            Console.WriteLine("calling DoSomeLongRunningTask() from LongRunningProcess class");
            Thread.Sleep(1000);
            Console.WriteLine("");
        }
    }
}
