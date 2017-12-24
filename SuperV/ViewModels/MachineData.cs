using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    public class MachineData
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string ProductCode { get; set; }
        public string WorkOperation { get; set; }
        public int TotalCount { get; set; }
        public int Speed { get; set; }
        public int Status { get; set; }
        public string BackgroundClass
        {
            get
            {
                switch (this.Status)
                {
                   
                    case 0:
                        return Constants.BG_COLOR_WORKING_STATUS;
                    case 1:
                        return Constants.BG_COLOR_STOPPED_STATUS;
                    default:
                        return string.Empty;
                }
            }
        }
        public string BackgroundStripeClass
        {
            get
            {
                switch (this.Status)
                {
                    case 0:
                        return Constants.BG_COLOR_WORKING_STATUS_STRIPE;
                    case 1:
                        return Constants.BG_COLOR_STOPPED_STATUS_STRIPE;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}