﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerSummary", Namespace="http://schemas.datacontract.org/2004/07/SatelliteService")]
    [System.SerializableAttribute()]
    public partial class ServerSummary : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AvailableMemoryMBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.DriveInfo[] DrivesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TotalMemoryMBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.ServerUpdateInfo[] UpdatesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AvailableMemoryMB {
            get {
                return this.AvailableMemoryMBField;
            }
            set {
                if ((this.AvailableMemoryMBField.Equals(value) != true)) {
                    this.AvailableMemoryMBField = value;
                    this.RaisePropertyChanged("AvailableMemoryMB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.DriveInfo[] Drives {
            get {
                return this.DrivesField;
            }
            set {
                if ((object.ReferenceEquals(this.DrivesField, value) != true)) {
                    this.DrivesField = value;
                    this.RaisePropertyChanged("Drives");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double TotalMemoryMB {
            get {
                return this.TotalMemoryMBField;
            }
            set {
                if ((this.TotalMemoryMBField.Equals(value) != true)) {
                    this.TotalMemoryMBField = value;
                    this.RaisePropertyChanged("TotalMemoryMB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.ServerUpdateInfo[] Updates {
            get {
                return this.UpdatesField;
            }
            set {
                if ((object.ReferenceEquals(this.UpdatesField, value) != true)) {
                    this.UpdatesField = value;
                    this.RaisePropertyChanged("Updates");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DriveInfo", Namespace="http://schemas.datacontract.org/2004/07/SatelliteService")]
    [System.SerializableAttribute()]
    public partial class DriveInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double FreeSpaceMBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LabelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double TotalSpaceMBField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double FreeSpaceMB {
            get {
                return this.FreeSpaceMBField;
            }
            set {
                if ((this.FreeSpaceMBField.Equals(value) != true)) {
                    this.FreeSpaceMBField = value;
                    this.RaisePropertyChanged("FreeSpaceMB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Label {
            get {
                return this.LabelField;
            }
            set {
                if ((object.ReferenceEquals(this.LabelField, value) != true)) {
                    this.LabelField = value;
                    this.RaisePropertyChanged("Label");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double TotalSpaceMB {
            get {
                return this.TotalSpaceMBField;
            }
            set {
                if ((this.TotalSpaceMBField.Equals(value) != true)) {
                    this.TotalSpaceMBField = value;
                    this.RaisePropertyChanged("TotalSpaceMB");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerUpdateInfo", Namespace="http://schemas.datacontract.org/2004/07/SatelliteService")]
    [System.SerializableAttribute()]
    public partial class ServerUpdateInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsDownloadedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsMandatoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReleaseDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDownloaded {
            get {
                return this.IsDownloadedField;
            }
            set {
                if ((this.IsDownloadedField.Equals(value) != true)) {
                    this.IsDownloadedField = value;
                    this.RaisePropertyChanged("IsDownloaded");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsMandatory {
            get {
                return this.IsMandatoryField;
            }
            set {
                if ((this.IsMandatoryField.Equals(value) != true)) {
                    this.IsMandatoryField = value;
                    this.RaisePropertyChanged("IsMandatory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReleaseDate {
            get {
                return this.ReleaseDateField;
            }
            set {
                if ((this.ReleaseDateField.Equals(value) != true)) {
                    this.ReleaseDateField = value;
                    this.RaisePropertyChanged("ReleaseDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MonitoringServiceReference.IMonitoringService")]
    public interface IMonitoringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoringService/GetServerSummary", ReplyAction="http://tempuri.org/IMonitoringService/GetServerSummaryResponse")]
        AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.ServerSummary GetServerSummary();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMonitoringServiceChannel : AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.IMonitoringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MonitoringServiceClient : System.ServiceModel.ClientBase<AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.IMonitoringService>, AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.IMonitoringService {
        
        public MonitoringServiceClient() {
        }
        
        public MonitoringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MonitoringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonitoringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonitoringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AspNetDeploy.DeploymentServices.WCFSatellite.MonitoringServiceReference.ServerSummary GetServerSummary() {
            return base.Channel.GetServerSummary();
        }
    }
}