using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class MachineDataDetailsVM
    {
        public int ID { get; set; }
        public string MachineName { get; set; }
        public string ProductCode { get; set; }
        public int Speed { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string BackgroundClass
        {
            get
            {
                return ClassHelper.GetBackgroundClass(this.Status);

            }
        }
        public string BackgroundStripeClass
        {
            get
            {
                return ClassHelper.GetBackgroundStripeClass(this.Status);
            }
        }
        public IEnumerable<MachineWorkItemVM> WorkItems { get; set; }
    }
}