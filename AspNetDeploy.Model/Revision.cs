
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
    
public partial class Revision
{

    public Revision()
    {

        this.ChildRevisions = new HashSet<Revision>();

        this.RevisionInfos = new HashSet<RevisionInfo>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public int SourceControlId { get; set; }

    public System.DateTime CreatedDate { get; set; }

    public Nullable<int> ParentRevisionId { get; set; }



    public virtual ICollection<Revision> ChildRevisions { get; set; }

    public virtual Revision ParentRevision { get; set; }

    public virtual SourceControlVersion SourceControlVersion { get; set; }

    public virtual ICollection<RevisionInfo> RevisionInfos { get; set; }

}

}
