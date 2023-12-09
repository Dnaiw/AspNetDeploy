﻿using AspNetDeploy.Contracts;
using AspNetDeploy.DeploymentServices.WCFSatellite;
using AspNetDeploy.Model;
using DeploymentServices.Grpc;


namespace AspNetDeploy.DeploymentServices
{
    public class GrpcDeploymentAgentFactory : IDeploymentAgentFactory
    {
        private readonly IVariableProcessorFactory variableProcessorFactory;

        public GrpcDeploymentAgentFactory(IVariableProcessorFactory variableProcessorFactory)
        {
            this.variableProcessorFactory = variableProcessorFactory;
        }

        public IDeploymentAgent Create(Machine machine, BundleVersion bundleVersion)
        {
            IVariableProcessor variableProcessor = this.variableProcessorFactory.Create(bundleVersion.Id, machine.Id);
            return new GrpcDeploymentAgent(variableProcessor, machine.URL, machine.Login, machine.Password);
        }
    }
}