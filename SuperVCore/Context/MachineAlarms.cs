//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperVCore.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class MachineAlarms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MachineAlarms()
        {
            this.Downtimes = new HashSet<Downtimes>();
            this.MachinesAlarmsLog = new HashSet<MachinesAlarmsLog>();
        }
    
        public byte ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Downtimes> Downtimes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachinesAlarmsLog> MachinesAlarmsLog { get; set; }
    }
}
