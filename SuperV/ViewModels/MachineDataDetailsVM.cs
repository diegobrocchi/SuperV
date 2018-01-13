using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class MachineDataDetailsVM
    {
        public IEnumerable<MachineWorkItemVM> WorkItems { get; set; }
    }
}