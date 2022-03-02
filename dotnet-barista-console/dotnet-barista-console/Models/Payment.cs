using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Models
{
    /// <summary>
    /// Payments from users
    /// </summary>
    public class Payment
    {
        public string user { get; set; }
        public int amount { get; set; }
    }

}
