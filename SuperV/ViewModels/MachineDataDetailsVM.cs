using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperV.ViewModels
{
    /// <summary>
    /// Rappresenta una macchina nel pannello di dettaglio. 
    /// </summary>
    public class MachineDataDetailsVM
    {
        /// <summary>
        /// Identificativo univoco della macchina.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Il nome della macchina.
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Il codice del prodotto.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// La velocità corrente.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Estremo inferiore delle date.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Estremo superiore delle date.
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Lo stato attuale della macchina.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Il nome dello stato attuale.
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Il nome della classe css da applicare alla visualizzazione.
        /// E' un dato di sola lettura e determinato dallo stato.
        /// </summary>
        public string BackgroundClass
        {
            get
            {
                return ClassHelper.GetBackgroundClass(this.Status);

            }
        }

        /// <summary>
        /// Il nome della classe css da applicare per la porzione evidenziata del pannello riepilogativo.
        /// </summary>
        public string BackgroundStripeClass
        {
            get
            {
                return ClassHelper.GetBackgroundStripeClass(this.Status);
            }
        }

        /// <summary>
        /// La lista dei work items lavorati dalla macchina nell'intervallo di tempo tra StartDate e StopDate.
        /// </summary>
        //public IEnumerable<MachineWorkItemVM> WorkItems { get; set; }

        public List<SuperVCore.Context.SP_AggegatedWorks_Machine_Result> WorkItemRows { get; set; }
    }
}