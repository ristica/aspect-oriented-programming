using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;
using PostSharp.Aspects;

namespace AOPSampleApp.Aspects
{
    [Serializable]
    public sealed class TransactionScopeAttribute : MethodInterceptionAspect
    {
        #region Fields

        private int _maxRetries = int.MaxValue;
        private int _retryDelay = 30;

        #endregion

        #region Properties

        public int MaxRetries
        {
            get
            {
                return this._maxRetries;
            }

            set
            {
                this._maxRetries = value;
            }
        }

        public int RetryDelay
        {
            get
            {
                return this._retryDelay;
            }

            set
            {
                this._retryDelay = value;
            }
        }

        #endregion

        #region Overrides

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var aggregateExceptions = new List<Exception>();
            var retries = 0;
            while (retries++ < this._maxRetries)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("starting transaction...");
                    using (var scope = new TransactionScope())
                    {
                        Console.WriteLine("transaction started...");
                        Console.WriteLine("start invoking method from aspect...");
                        args.Proceed();
                        Console.WriteLine("method invokation done...");
                        scope.Complete();
                        Console.WriteLine("scope completed...");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    aggregateExceptions.Add(ex);
                    if (retries >= this._maxRetries)
                    {
                        throw new AggregateException($"Trasaction failed after {this._maxRetries} attempts", aggregateExceptions);
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(this._retryDelay));
                }
            }
        }

        #endregion
    }
}
