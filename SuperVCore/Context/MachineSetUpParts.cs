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
    
    public partial class MachineSetUpParts
    {
        public int ID { get; set; }
        public Nullable<byte> MachineID { get; set; }
        public Nullable<int> SetUpPartID { get; set; }
    
        public virtual Machines Machines { get; set; }
        public virtual SetUpParts SetUpParts { get; set; }
    }
}
