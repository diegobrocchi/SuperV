using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class MachineProcessingStepsVM
    {
        public string Name { get; set; }
        public int? TotalMinutes { get; set; }
        public decimal? Waste { get; set; }
    }
}