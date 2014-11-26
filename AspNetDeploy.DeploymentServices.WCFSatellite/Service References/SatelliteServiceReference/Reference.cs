﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetDeploy.DeploymentServices.WCFSatellite.SatelliteServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SatelliteServiceReference.IDeploymentService")]
    public interface IDeploymentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/IsReady", ReplyAction="http://tempuri.org/IDeploymentService/IsReadyResponse")]
        bool IsReady();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/BeginPublication", ReplyAction="http://tempuri.org/IDeploymentService/BeginPublicationResponse")]
        bool BeginPublication(int publicationId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/ExecuteNextOperation", ReplyAction="http://tempuri.org/IDeploymentService/ExecuteNextOperationResponse")]
        bool ExecuteNextOperation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/Complete", ReplyAction="http://tempuri.org/IDeploymentService/CompleteResponse")]
        bool Complete();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/Rollback", ReplyAction="http://tempuri.org/IDeploymentService/RollbackResponse")]
        bool Rollback();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/UploadPackageBuffer", ReplyAction="http://tempuri.org/IDeploymentService/UploadPackageBufferResponse")]
        void UploadPackageBuffer(byte[] buffer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/ResetPackage", ReplyAction="http://tempuri.org/IDeploymentService/ResetPackageResponse")]
        void ResetPackage();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/DeployWebSite", ReplyAction="http://tempuri.org/IDeploymentService/DeployWebSiteResponse")]
        void DeployWebSite(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/ProcessConfigFile", ReplyAction="http://tempuri.org/IDeploymentService/ProcessConfigFileResponse")]
        void ProcessConfigFile(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/RunPowerShellScript", ReplyAction="http://tempuri.org/IDeploymentService/RunPowerShellScriptResponse")]
        void RunPowerShellScript();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/CopyFiles", ReplyAction="http://tempuri.org/IDeploymentService/CopyFilesResponse")]
        void CopyFiles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/UpdateHostsFile", ReplyAction="http://tempuri.org/IDeploymentService/UpdateHostsFileResponse")]
        void UpdateHostsFile();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeploymentService/RunSQLScript", ReplyAction="http://tempuri.org/IDeploymentService/RunSQLScriptResponse")]
        void RunSQLScript();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeploymentServiceChannel : AspNetDeploy.DeploymentServices.WCFSatellite.SatelliteServiceReference.IDeploymentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeploymentServiceClient : System.ServiceModel.ClientBase<AspNetDeploy.DeploymentServices.WCFSatellite.SatelliteServiceReference.IDeploymentService>, AspNetDeploy.DeploymentServices.WCFSatellite.SatelliteServiceReference.IDeploymentService {
        
        public DeploymentServiceClient() {
        }
        
        public DeploymentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeploymentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeploymentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeploymentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsReady() {
            return base.Channel.IsReady();
        }
        
        public bool BeginPublication(int publicationId) {
            return base.Channel.BeginPublication(publicationId);
        }
        
        public bool ExecuteNextOperation() {
            return base.Channel.ExecuteNextOperation();
        }
        
        public bool Complete() {
            return base.Channel.Complete();
        }
        
        public bool Rollback() {
            return base.Channel.Rollback();
        }
        
        public void UploadPackageBuffer(byte[] buffer) {
            base.Channel.UploadPackageBuffer(buffer);
        }
        
        public void ResetPackage() {
            base.Channel.ResetPackage();
        }
        
        public void DeployWebSite(string json) {
            base.Channel.DeployWebSite(json);
        }
        
        public void ProcessConfigFile(string json) {
            base.Channel.ProcessConfigFile(json);
        }
        
        public void RunPowerShellScript() {
            base.Channel.RunPowerShellScript();
        }
        
        public void CopyFiles() {
            base.Channel.CopyFiles();
        }
        
        public void UpdateHostsFile() {
            base.Channel.UpdateHostsFile();
        }
        
        public void RunSQLScript() {
            base.Channel.RunSQLScript();
        }
    }
}