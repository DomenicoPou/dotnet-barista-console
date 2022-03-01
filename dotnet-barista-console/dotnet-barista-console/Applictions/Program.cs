using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using System;
using System.Collections.Generic;

namespace dotnet_barista_console
{
    /***
        - Load the list of prices
        - Load the orders
          - Calculate the total cost of each user's orders
        - Load the payments
          - Calculate the total payment for each user
          - Calculate what each user now owes
        - Output a JSON string containing the results of this work.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> MenuItems = DataHandler.ReadConfig<List<MenuItem>>("prices");
            List<Order> orders = DataHandler.ReadConfig<List<Order>>("orders");
            // Calculate the total cost of each user's orders

            List<Payment> Payments = DataHandler.ReadConfig<List<Payment>>("payments");
            // Calculate the total payment for each user
            // Calculate what each user now owes

            // Output a JSON string containing the results of this work.
            Console.WriteLine("Hello World!");
        }
    }
}
