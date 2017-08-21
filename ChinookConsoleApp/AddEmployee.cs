﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class AddEmployee
    {
        public void Add()
        {
            Console.WriteLine("Enter first name:");
            var x = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var y = Console.ReadLine();



            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();

                    var rowsAffected = connection.Execute("Insert into Employee(FirstName, LastName) " +
                                                          "Values(@FirstName, @LastName)",
                        new {FirstName = x, LastName = y});

                    Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("You done messed up");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }


                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}