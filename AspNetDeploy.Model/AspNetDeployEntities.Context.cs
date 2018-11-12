﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AspNetDeployEntities : DbContext
    {
        public AspNetDeployEntities()
            : base("name=AspNetDeployEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bundle> Bundle { get; set; }
        public virtual DbSet<BundleVersion> BundleVersion { get; set; }
        public virtual DbSet<DeploymentStep> DeploymentStep { get; set; }
        public virtual DbSet<DeploymentStepProperty> DeploymentStepProperty { get; set; }
        public virtual DbSet<Environment> Environment { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineRole> MachineRole { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectProperty> ProjectProperty { get; set; }
        public virtual DbSet<ProjectVersion> ProjectVersion { get; set; }
        public virtual DbSet<SourceControl> SourceControl { get; set; }
        public virtual DbSet<SourceControlProperty> SourceControlProperty { get; set; }
        public virtual DbSet<SourceControlVersion> SourceControlVersion { get; set; }
        public virtual DbSet<SourceControlVersionProperty> SourceControlVersionProperty { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<BundleVersionProperty> BundleVersionProperty { get; set; }
        public virtual DbSet<ProjectVersionProperty> ProjectVersionProperty { get; set; }
        public virtual DbSet<MachinePublication> MachinePublication { get; set; }
        public virtual DbSet<MachinePublicationLog> MachinePublicationLog { get; set; }
        public virtual DbSet<MachinePublicationProperty> MachinePublicationProperty { get; set; }
        public virtual DbSet<EnvironmentProperty> EnvironmentProperty { get; set; }
        public virtual DbSet<DataField> DataField { get; set; }
        public virtual DbSet<PackageApprovedOnEnvironment> PackageApprovedOnEnvironment { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<PackageEntry> PackageEntry { get; set; }
        public virtual DbSet<AspNetDeployExceptionEntry> AspNetDeployExceptionEntry { get; set; }
        public virtual DbSet<ExceptionEntryData> ExceptionEntryData { get; set; }
        public virtual DbSet<ExceptionEntry> ExceptionEntry { get; set; }
        public virtual DbSet<DataFieldValue> DataFieldValue { get; set; }
        public virtual DbSet<EnvironmentChain> EnvironmentChain { get; set; }
    }
}
