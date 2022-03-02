using dotnet_barista_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Handlers
{
    public class MenuHandler
    {
        public static Dictionary<string, MenuItem> MenuItems;

        public MenuHandler ()
        {

            MenuItems = DataHandler.ReadConfig<List<MenuItem>>("prices").ToDictionary(x => x.drink_name);
        }

        public float ObtainPrice(Order order)
        {
            if (!MenuItems.ContainsKey(order.drink))
                throw new ArgumentException($"Unkown drink was ordered: {order.drink}");

            MenuItem item = MenuItems[order.drink];

            if (!item.prices.ContainsKey(order.size))
                throw new ArgumentException($"Unkown drink size was ordered: {order.drink} {order.size}");

            return item.prices[order.size];
        }
    }
}
