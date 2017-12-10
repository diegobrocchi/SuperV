using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class MachineData
    {
        public int MachineID { get; set; }
        public string ProductCode { get; set; }
        public int TotalCount { get; set; }
        public int Speed { get; set; }
        public int Status { get; set; }
    }
}