using dotnet_barista_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Handlers
{
    /// <summary>
    /// Menu Handler will handle all calculation and viewing of the menu item "prices" data
    /// </summary>
    public class MenuHandler
    {
        // Dictionary for ease of use. For optimising large order lists.
        public static Dictionary<string, MenuItem> MenuItems;

        public MenuHandler ()
        {

            MenuItems = DataHandler.ReadConfig<List<MenuItem>>("prices").ToDictionary(x => x.drink_name);
        }

        /// <summary>
        /// Obtain the price of an order
        /// </summary>
        /// <param name="order">A users order we are searching the prices for</param>
        /// <returns>The price in dollar amount</returns>
        public float ObtainPrice(Order order)
        {
            // Check if the drink exists on the menu
            if (!MenuItems.ContainsKey(order.drink))
                throw new ArgumentException($"Unkown drink was ordered: {order.drink}");

            // Obtain the menu item
            MenuItem item = MenuItems[order.drink];

            // Check if the drink size exists
            if (!item.prices.ContainsKey(order.size))
                throw new ArgumentException($"Unkown drink size was ordered: {order.drink} {order.size}");
            
            // Return the price of the drink relative to the size
            return item.prices[order.size];
        }
    }
}
