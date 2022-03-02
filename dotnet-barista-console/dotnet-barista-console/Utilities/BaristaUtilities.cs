using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Utilities
{
    /// <summary>
    /// Handles all calculations
    /// </summary>
    public class BaristaUtilities
    {
        private MenuHandler menuHandler;
        private List<Order> orders;
        private List<Payment> Payments;

        /// <summary>
        /// Load the list of data handlers, data in general that will handle the calculations
        /// </summary>
        public BaristaUtilities()
        {
            // Load the list of menu items which handles the 'prices' json
            menuHandler = new MenuHandler();

            // Load the orders
            orders = DataHandler.ReadConfig<List<Order>>("orders");

            //Load the payments
            Payments = DataHandler.ReadConfig<List<Payment>>("payments");
        }


        public List<BaristaResponse> ObtainBaristaTotals()
        {
            // I assume the user base will always include customers that have ordered at least one drink.
            // So generate a user dictionary with the barista response.
            Dictionary<string, BaristaResponse> response = orders.GroupBy(x => x.user).ToDictionary(x => x.Key, y => new BaristaResponse()
            {
                user = y.Key
            });

            // Calculate the total cost of each user's orders
            foreach (Order order in orders)
            {
                response[order.user].order_total += menuHandler.ObtainPrice(order);
            }

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

            // Return the list of barista responses
            return response.Values.ToList();
        }

        // Just a note: I've already spent maybe a couple hours doing this project. Ill just say that the calculations would be implemented in their designated handler/utitlity.
    }
}
