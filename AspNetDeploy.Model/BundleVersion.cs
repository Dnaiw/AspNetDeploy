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
    
    public partial class BundleVersion
    {
        public BundleVersion()
        {
            this.DeploymentSteps = new HashSet<DeploymentStep>();
            this.ProjectVersions = new HashSet<ProjectVersion>();
            this.Packages = new HashSet<Package>();
            this.Properties = new HashSet<BundleVersionProperty>();
            this.DataFields = new HashSet<DataField>();
            this.ChildBundleVersions = new HashSet<BundleVersion>();
        }
    
        public int Id { get; set; }
        public int BundleId { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public bool IsHead { get; set; }
        public Nullable<int> ParentBundleVersionId { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Bundle Bundle { get; set; }
        public virtual ICollection<DeploymentStep> DeploymentSteps { get; set; }
        public virtual ICollection<ProjectVersion> ProjectVersions { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<BundleVersionProperty> Properties { get; set; }
        public virtual ICollection<DataField> DataFields { get; set; }
        public virtual ICollection<BundleVersion> ChildBundleVersions { get; set; }
        public virtual BundleVersion ParentBundleVersion { get; set; }
    }
}
