
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
    
public partial class ProjectVersion
{

    public ProjectVersion()
    {

        this.BundleVersions = new HashSet<BundleVersion>();

        this.Properties = new HashSet<ProjectVersionProperty>();

        this.PackageEntries = new HashSet<PackageEntry>();

    }


    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int SourceControlVersionId { get; set; }

    public ProjectType ProjectType { get; set; }

    public string SolutionFile { get; set; }

    public string ProjectFile { get; set; }

    public bool IsDeleted { get; set; }

    public string Name { get; set; }



    public virtual Project Project { get; set; }

    public virtual SourceControlVersion SourceControlVersion { get; set; }

    public virtual ICollection<BundleVersion> BundleVersions { get; set; }

    public virtual ICollection<ProjectVersionProperty> Properties { get; set; }

    public virtual ICollection<PackageEntry> PackageEntries { get; set; }

}

}
