using System;
using AOPSampleApp.DataContracts;

namespace AOPSampleApp.Program_Manager
{
    public class TestService : ITestService
    {
        public Person GetPerson()
        {
            var person = new Person
            {
                Id = 0,
                FirstName = "Pingo",
                LastName = "Pongo",
                Email = "pingo@pongo.at"
            };

            Console.WriteLine("\tCalling DoSomething() from TestService...");

            return person;
        }
    }
}
