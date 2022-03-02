using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            // Load the list of prices as dictionary for ease of use
            MenuHandler menuHandler = new MenuHandler();

            // Load the orders
            List<Order> orders = DataHandler.ReadConfig<List<Order>>("orders");

            // Calculate the total cost of each user's orders
            Dictionary<string, BaristaResponse> response = orders.GroupBy(x => x.user).ToDictionary(x => x.Key, y => new BaristaResponse()
            {
                user = y.Key
            });

            foreach (Order order in orders)
            {
                response[order.user].order_total += menuHandler.ObtainPrice(order);
            }

            //Load the payments
            List<Payment> Payments = DataHandler.ReadConfig<List<Payment>>("payments");

            // Calculate the total payment for each user
            foreach (Payment payment in Payments)
            {
                response[payment.user].payment_total += payment.amount;
            }

            // Calculate what each user now owes
            foreach (string user in response.Keys)
            {
                response[user].balance = response[user].payment_total - response[user].order_total;
            }

            ///return response.Values.ToList();

            // Output a JSON string containing the results of this work.
            Console.WriteLine("Hello World!");
        }
    }
}
