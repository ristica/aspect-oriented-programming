using System;
using PostSharp.Extensibility;
using System.Diagnostics;

namespace AOPSampleApp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public sealed class TimingAspect : PostSharp.Aspects.OnMethodBoundaryAspect
    {
        [NonSerialized]
        private Stopwatch _stopWatch;

        public override void OnEntry(PostSharp.Aspects.MethodExecutionArgs args)
        {
            _stopWatch = Stopwatch.StartNew();

            base.OnEntry(args);
        }

        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            Console.WriteLine("");
            Console.WriteLine("{0} took {1}ms to execute", new StackTrace().GetFrame(1).GetMethod().Name, _stopWatch.ElapsedMilliseconds);
            Console.WriteLine("");
            base.OnExit(args);
        }
    }
}
