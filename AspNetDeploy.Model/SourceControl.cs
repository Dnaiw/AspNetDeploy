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
    
    public partial class SourceControl
    {
        public SourceControl()
        {
            this.Projects = new HashSet<Project>();
            this.Properties = new HashSet<SourceControlProperty>();
            this.SourceControlVersions = new HashSet<SourceControlVersion>();
            this.Groups = new HashSet<Group>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public SourceControlType Type { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderIndex { get; set; }
    
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<SourceControlProperty> Properties { get; set; }
        public virtual ICollection<SourceControlVersion> SourceControlVersions { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
