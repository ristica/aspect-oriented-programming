using System;
using PostSharp.Aspects;

namespace AOPSampleApp.Aspects
{
    /// <summary>
    /// if we need more sophisticated exception handling then we could have wit
    /// our logging aspect
    /// </summary>
    [Serializable]
    public sealed class ExceptionHandlerAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("Exception in :[{0}] , Message:[{1}]", args.Method, args.Exception.Message);

            // FlowBehavior is important then if not included
            // the code stops executing
            args.FlowBehavior = FlowBehavior.Continue;

            base.OnException(args);
        }
    }
}
