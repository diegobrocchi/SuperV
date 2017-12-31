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
        public byte Status { get; set; }
        public string BackgroundClass
        {
            get
            {
                switch (this.Status)
                {
                   
                    case 0:
                        return Constants.BG_COLOR_DISCONNECTED ;
                    case 1:
                        return Constants.BG_COLOR_EMERGENCY;
                    case 2:
                        return Constants.BG_COLOR_ALARM ;
                    case 3:
                        return Constants.BG_COLOR_RUN;
                    case 4:
                        return Constants.BG_COLOR_RUN_ALARM;
                    case 5:
                        return Constants.BG_COLOR_STOPPED_STATUS;
                    case 6:
                        return Constants.BG_COLOR_SETUP;
                    case 7:
                        return Constants.BG_COLOR_STARTUP;
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
                        return Constants.BG_COLOR_DISCONNECTED_STRIPE;
                    case 1:
                        return Constants.BG_COLOR_EMERGENCY_STRIPE ;
                    case 2:
                        return Constants.BG_COLOR_ALARM_STRIPE ;
                    case 3:
                        return Constants.BG_COLOR_RUN_STRIPE;
                    case 4:
                        return Constants.BG_COLOR_RUN_ALARM_STRIPE;
                    case 5:
                        return Constants.BG_COLOR_STOPPED_STATUS_STRIPE;
                    case 6:
                        return Constants.BG_COLOR_SETUP_STRIPE;
                    case 7:
                        return Constants.BG_COLOR_STARTUP_STRIPE;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}