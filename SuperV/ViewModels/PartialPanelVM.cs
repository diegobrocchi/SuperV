using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class PartialPanelVM
    {
        public PartialPanelVM()
        {
            MachinesData = new List<MachineData>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Now { get; set; }

        public List<MachineData> MachinesData { get; set; }
    }
}