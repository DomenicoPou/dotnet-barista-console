using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using dotnet_barista_console.Utilities;
using Newtonsoft.Json;
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
            BaristaUtilities baristaUtilities = new BaristaUtilities();
            List<BaristaResponse> Result = baristaUtilities.ObtainBaristaTotals();
            Console.WriteLine(JsonConvert.SerializeObject(Result, Formatting.Indented));
            ///return response.Values.ToList();

            // Output a JSON string containing the results of this work.
        }
    }
}
