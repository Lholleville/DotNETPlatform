using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceAPI.Models
{
    public class Devices
    {
        public double IdDevice { get; set; }
        public String Mac { get; set; }
        public String Name { get; set; }
        public int Type { get; set; }
        public double NoV { get; set; }
        public String Value { get; set; }
        public int Old { get; set; }
    }
}