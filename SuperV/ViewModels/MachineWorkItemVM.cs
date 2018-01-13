using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    /// <summary>
    /// Rappresenta il riepilogo del lavoro svolto da una macchina.
    /// Viene calcolato selezionando tutti i lavori svolti da una macchina 
    /// raggruppati per 'code' del lavoro.
    /// </summary>
    public class MachineWorkItemVM
    {
        /// <summary>
        /// Il codice del lavoro.
        /// </summary>
        public string Code { get; set; }
        public IEnumerable<int> IDs { get; set; }
        public double Quantity { get; set; }
        public double QuantityMade { get; set; }
        public double QuantityWasted { get; set; }
        public string UM { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }
        public int Minutes { get; set; }
    }
}