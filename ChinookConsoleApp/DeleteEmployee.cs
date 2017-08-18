using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void delete()
        {
            Console.Clear();
            

            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                var employeeListCommand = connection.CreateCommand();

                employeeListCommand.CommandText = "select employeeid as Id, " +
                                                  "firstname + ' ' + lastname as fullname " +
                                                  "from Employee";

                try
                {
                    connection.Open();
                    var reader = employeeListCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}.) {reader["FullName"]}");
                    }

                    Console.WriteLine("8=============D");
                    Console.WriteLine("Select Employee to Delete");
                    var del = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}