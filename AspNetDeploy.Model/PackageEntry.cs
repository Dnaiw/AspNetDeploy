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
    
    public partial class PackageEntry
    {
        public int PackageId { get; set; }
        public int ProjectVersionId { get; set; }
        public string Revision { get; set; }
    
        public virtual Package Package { get; set; }
        public virtual ProjectVersion ProjectVersion { get; set; }
    }
}
