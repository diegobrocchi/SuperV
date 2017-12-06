using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVApi.Models
{
    public class MachineStatus
    {
        public int MachineID { get; set; }
        public string ProductCode { get; set; }
        public int MachineState { get; set; }
        public int Speed { get; set; }
        public int Counter { get; set; }
        public int ResettableCounter { get; set; }
        public int AverageSpeed { get; set; }
    }
}