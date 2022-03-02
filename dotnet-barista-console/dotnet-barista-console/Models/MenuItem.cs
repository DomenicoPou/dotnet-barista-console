using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_barista_console.Models
{
    /// <summary>
    /// The menu items consisting of drink name and its size prizes
    /// </summary>
    public class MenuItem
    {
        public string drink_name { get; set; }
        public Dictionary<string, float> prices { get; set; }
    }
}
