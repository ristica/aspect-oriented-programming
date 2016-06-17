using System;
using PostSharp.Aspects;
using System.Transactions;
using PostSharp.Aspects.Dependencies;

namespace AOPSampleApp.Aspects
{
    [Serializable]
    [AspectTypeDependency(AspectDependencyAction.Order, 
                          AspectDependencyPosition.After, typeof(LogAspect))]
    public sealed class TransactionAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private TransactionScope _transactionScope;

        public override void OnEntry(MethodExecutionArgs args)
        {
            this._transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            this._transactionScope.Complete();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            // important!!!
            args.FlowBehavior = FlowBehavior.Continue;

            Transaction.Current.Rollback();
            Console.WriteLine("Transaction Was Unsuccessful!");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            this._transactionScope.Dispose();
        }
    }
}
