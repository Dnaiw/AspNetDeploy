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
    
    public partial class Environment
    {
        public Environment()
        {
            this.Machines = new HashSet<Machine>();
            this.Publication = new HashSet<Publication>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
    
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Publication> Publication { get; set; }
    }
}
