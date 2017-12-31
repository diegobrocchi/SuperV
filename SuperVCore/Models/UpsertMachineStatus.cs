using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVCore.Models
{
    public  class UpsertMachineStatus
    {
        public byte MachineID { get; set; }
        public int Counter { get; set; }
        public byte MachineStatus { get; set; }
        public int Speed { get; set; }
        public string ProductCode { get; set; }
        public int AverageSpeed  { get; set; }
        public int ResettableCounter { get; set; }
    }
}
