using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Models
{
    /// <summary>
    /// Transactions from users that ordered menu items
    /// </summary>
    public class Order
    {
        public string user { get; set; }
        public string drink { get; set; }
        public string size { get; set; }
    }
}
