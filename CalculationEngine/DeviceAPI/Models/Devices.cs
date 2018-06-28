using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceAPI.Models
{
    public class Devices
    {
        public int IdDevice { get; set; }
        public String Mac { get; set; }
        public int NoV { get; set; }
        public int Value { get; set; }
    }
}