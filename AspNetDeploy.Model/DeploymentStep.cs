
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
    
public partial class DeploymentStep
{

    public DeploymentStep()
    {

        this.ChildSteps = new HashSet<DeploymentStep>();

        this.Properties = new HashSet<DeploymentStepProperty>();

        this.MachineRoles = new HashSet<MachineRole>();

    }


    public int Id { get; set; }

    public Nullable<int> DeploymentStepId { get; set; }

    public int BundleVersionId { get; set; }

    public int OrderIndex { get; set; }

    public DeploymentStepType Type { get; set; }



    public virtual BundleVersion BundleVersion { get; set; }

    public virtual ICollection<DeploymentStep> ChildSteps { get; set; }

    public virtual DeploymentStep Parent { get; set; }

    public virtual ICollection<DeploymentStepProperty> Properties { get; set; }

    public virtual ICollection<MachineRole> MachineRoles { get; set; }

}

}
