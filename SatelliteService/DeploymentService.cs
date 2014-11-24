﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using Newtonsoft.Json;
using ObjectFactory;
using SatelliteService.Contracts;
using SatelliteService.Operations;

namespace SatelliteService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class DeploymentService : IDeploymentService
    {
        private int activePublicationId;

        private readonly IPathRepository pathRepository;
        private readonly IBackupRepository backupRepository;
        private readonly IPackageRepositoryFactory packageRepositoryFactory;

        private int nextOperationIndex = 0;
        private IList<Operation> queuedOperations = new List<Operation>();
        private IList<Operation> completedOperations = new List<Operation>();

        public DeploymentService()
        {
            this.pathRepository = Factory.GetInstance<IPathRepository>();
            this.backupRepository = Factory.GetInstance<IBackupRepository>();
            this.packageRepositoryFactory = Factory.GetInstance<IPackageRepositoryFactory>();
        }

        public bool IsReady()
        {
            return this.activePublicationId == 0;
        }

        public bool BeginPublication(int publicationId)
        {
            if (this.activePublicationId != 0)
            {
                return false;
            }

            Console.WriteLine("Begin publication: " + publicationId);

            this.activePublicationId = publicationId;
            this.queuedOperations = new List<Operation>();
            this.completedOperations = new List<Operation>();
            this.nextOperationIndex = 0;

            return true;
        }

        public bool ExecuteNextOperation()
        {
            if (this.nextOperationIndex == this.queuedOperations.Count)
            {
                return false;
            }

            try
            {
                Operation operation = this.queuedOperations[this.nextOperationIndex];

                Console.Write("Executing operation: " + this.nextOperationIndex);
                operation.Run();
                Console.Write("– OK\n\r");
                this.completedOperations.Add(operation);
                this.nextOperationIndex++;

                return true;
            }
            catch (Exception)
            {
                Console.Write("– Error\n\r");
                this.Rollback();
                
                return false;
            }
        }

        public bool Complete()
        {
            this.activePublicationId = 0;
            this.completedOperations.Clear();
            this.queuedOperations.Clear();

            Console.WriteLine("Publication complete");

            return true;
        }

        public bool Rollback()
        {
            Console.WriteLine("Rolling back");

            foreach (Operation operation in this.completedOperations.Reverse())
            {
                operation.Rollback();
            }

            this.activePublicationId = 0;
            this.completedOperations.Clear();

            Console.WriteLine("Rollback complete");

            return true;
        }

        public void ResetPackage()
        {
            if (File.Exists(this.pathRepository.GetPackagePath(this.activePublicationId)))
            {
                File.Delete(this.pathRepository.GetPackagePath(this.activePublicationId));
            }
        }

        public void UploadPackageBuffer(byte[] buffer)
        {
            using (FileStream fileStream = new FileStream(this.pathRepository.GetPackagePath(this.activePublicationId), FileMode.Append, FileAccess.Write, FileShare.None))
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }

        public void DeployWebSite(string jsonConfig)
        {
            string packagePath = pathRepository.GetPackagePath(this.activePublicationId);
            WebSiteOperation operation = new WebSiteOperation(this.backupRepository, this.packageRepositoryFactory.Create(packagePath));
            operation.Configure(JsonConvert.DeserializeObject(jsonConfig));

            this.queuedOperations.Add(operation);
        }

        public void ProcessConfigFile(string jsonConfig)
        {
            ConfigOperation operation = Factory.GetInstance<ConfigOperation>();
            operation.Configure(JsonConvert.DeserializeObject(jsonConfig));

            this.queuedOperations.Add(operation);
        }

        public void RunPowerShellScript()
        {
            throw new System.NotImplementedException();
        }

        public void CopyFiles()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateHostsFile()
        {
            throw new System.NotImplementedException();
        }

        public void RunSQLScript()
        {
            throw new System.NotImplementedException();
        }
    }
}