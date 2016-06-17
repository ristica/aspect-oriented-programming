using System;
using AOPSampleApp.Aspects;

namespace AOPSampleApp.Salary
{
    public class EmployeeSalary
    {
        [ExceptionHandlerAspect]
        [LogAspect]
        public void Calc()
        {
            Console.WriteLine("");
            Console.WriteLine("calling Calc method from EmployeSalary class...");
            throw new ApplicationException("Somethng happened during calculation...");
        }
    }
}
