//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetDeploy.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataFieldValue
    {
        public int Id { get; set; }
        public int DataFieldId { get; set; }
        public string Value { get; set; }
        public Nullable<int> EnvironmentId { get; set; }
        public Nullable<int> MachineId { get; set; }
    
        public virtual DataField DataField { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
