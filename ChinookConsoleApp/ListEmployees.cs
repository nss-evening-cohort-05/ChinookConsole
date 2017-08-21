using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{  
    public class EmployeeListResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public class ListEmployees
    {
        public void List()
        {
            Console.Clear();

            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                connection.Query<>
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

                    Console.WriteLine("Press enter to return to the menu.");
                    Console.ReadLine();
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