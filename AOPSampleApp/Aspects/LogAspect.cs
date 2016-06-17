using System;
using PostSharp.Aspects;

namespace AOPSampleApp.Aspects
{
    [Serializable]
    public sealed class LogAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("");
            Console.WriteLine("OnEntry => called in {0} ...", args.Method);

            base.OnEntry(args);
        }

        ///// <summary>
        /////  in this example we don't need OnSuccess because
        ///// we are throwing an exception anyway!
        ///// </summary>
        ///// <param name="args"></param>
        //public override void OnSuccess(MethodExecutionArgs args)
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("OnSuccess => called in {0} ...", args.Method);

        //    base.OnSuccess(args);
        //}

        ///// <summary>
        ///// if we are going to use ExceptionAspect comment this out
        ///// </summary>
        ///// <param name = "args" ></ param >
        //public override void OnException(MethodExecutionArgs args)
        //{
        //    Console.WriteLine("");
        //    Console.WriteLine("OnException => called in {0} ...", args.Method);
        //    base.OnException(args);
        //}

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("OnExit => called in {0} ...", args.Method);

            base.OnExit(args);
        }
    }
}
