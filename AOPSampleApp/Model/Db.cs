using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AOPSampleApp.Aspects;
using AOPSampleApp.DataContracts;

namespace AOPSampleApp.Model
{
    /// <summary>
    /// take a look at the class with IL Spy tool
    /// and you will se OnEntry, OnSuccess, OnExit and OnException methods adda
    /// and try/catch-es too!
    /// </summary>
    public class Db
    {
        //[LogAspect]
        [TransactionScope(MaxRetries = 3, RetryDelay = 1)]
        public void Create(Person person)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "ATZWS136448\\SQLSERVER2014",
                InitialCatalog = "aop",
                IntegratedSecurity = true
            };

            var sql = $"INSERT INTO Person VALUES ('{person.FirstName}','{person.LastName}','{person.Email}')";

            using (var sqlConn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                Console.WriteLine("\tcreating command object...");
                using (var sqlComm = new SqlCommand(sql, sqlConn))
                {
                    Console.WriteLine("\topen connection to the db...");
                    sqlConn.Open();
                    Console.WriteLine("\tconnection to the db opened...");
                    Console.WriteLine("\texecute command...");
                    using (var sqlReader = sqlComm.ExecuteReader())
                    {
                        Console.WriteLine("\t{0} => saved!", person.FirstName + " " + person.LastName);
                    }
                }
            }
            Console.WriteLine("\tCreate done!");
        }
    }
}
