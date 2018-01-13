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

        /// <summary>
        /// Indica il nome della classe CSS che esprime il colore del background in relazione allo stato della macchina.
        /// </summary>
        public string BackgroundClass
        {
            get
            {
               return  ClassHelper.GetBackgroundClass(this.Status);
                
            }
        }
        public string BackgroundStripeClass
        {
            get
            {
                return ClassHelper.GetBackgroundStripeClass(this.Status);

                
            }
        }
    }
}