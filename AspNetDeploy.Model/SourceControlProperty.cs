
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
    
public partial class SourceControlProperty
{

    public int Id { get; set; }

    public int SourceControlId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }



    public virtual SourceControl SourceControl { get; set; }

}

}
