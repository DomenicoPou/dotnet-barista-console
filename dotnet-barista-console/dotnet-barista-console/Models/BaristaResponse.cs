using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Models
{
    public class BaristaResponse
    {
        public string user { get; set; }
        public float order_total { get; set; }
        public float payment_total { get; set; }
        public float balance { get; set; }
    }

}
