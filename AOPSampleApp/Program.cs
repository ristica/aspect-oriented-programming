using System;
using System.Diagnostics;
using System.ServiceModel;
using AOPSampleApp.Client;
using AOPSampleApp.DataContracts;
using AOPSampleApp.Model;
using AOPSampleApp.Program_Manager;
using AOPSampleApp.Salary;

namespace AOPSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            StartServiceHosting();

            Console.WriteLine("---------------");

            // 2 - test DataMember aspect
            DoServiceCall();

            Console.WriteLine("---------------");

            // 3 - throw an exception
            new EmployeeSalary().Calc();
            Console.WriteLine("");

            Console.WriteLine("---------------");

            // 4 - do nightly build
            new NightBuild.LongRunningProcess().DoSomeLongRunningTask();

            Console.WriteLine("---------------");

            // 5 - transaction handling
            new Db().Create(
                new Person
                {
                    FirstName = "Aleksandar",
                    LastName = "Ristic",
                    Email = "al.ri@gmx.at"
                });

            Console.WriteLine("");
            Console.WriteLine("---------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void StartServiceHosting()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("start hosting the service...");

                var host = new ServiceHost(typeof(TestService));
                host.Open();

                Console.WriteLine("service runs...");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Debugger.Break();
                throw;
            }
        }

        private static void DoServiceCall()
        {
            Console.WriteLine("");
            Console.WriteLine("START - DoServiceCall()");

            var proxy = new TestClient();
            var person = proxy.GetPerson();
            Console.WriteLine("\tPerson: {0} - {1} {2} => {3}", person.Id, person.FirstName, person.LastName, person.Email);
            Console.WriteLine("ENDE - DoServiceCall()");
            Console.WriteLine("");
        }
    }
}
