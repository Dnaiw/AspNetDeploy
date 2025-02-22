﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using AspNetDeploy.Contracts;
using AspNetDeploy.Contracts.Exceptions;
using AspNetDeploy.Model;
using SharpSvn;

namespace AspNetDeploy.SourceControls.SVN
{
    public class SvnSourceControlRepository : ISourceControlRepository
    {
        public bool CreateNewVersion(SourceControlVersion from, SourceControlVersion to)
        {
            NetworkCredential credentials = new NetworkCredential(
                        from.SourceControl.GetStringProperty("Login"),
                        from.SourceControl.GetStringProperty("Password"));

            using (SvnClient client = new SvnClient())
            {
                client.Authentication.DefaultCredentials = credentials;

                SvnTarget svnTarget = new SvnPathTarget(this.GetVersionURI(from));

                client.RemoteCopy(svnTarget, new Uri(this.GetVersionURI(to)));

                return true;
            }
        }

        public TestSourceResult TestConnection(SourceControlVersion sourceControlVersion)
        {
            NetworkCredential credentials = new NetworkCredential(
                        sourceControlVersion.SourceControl.GetStringProperty("Login"),
                        sourceControlVersion.SourceControl.GetStringProperty("Password"));

            using (SvnClient client = new SvnClient())
            {
                client.LoadConfiguration(Path.Combine(Path.GetTempPath(), "Svn"), true);

                client.Authentication.DefaultCredentials = credentials;

                try
                {
                    SvnInfoEventArgs info;
                    client.GetInfo(new Uri(this.GetVersionURI(sourceControlVersion)), out info);
                }
                catch (SvnException e)
                {
                    return new TestSourceResult()
                    {
                        IsSuccess = false,
                        ErrorMessage = e.Message
                    };
                }

                return new TestSourceResult()
                {
                    IsSuccess = true,
                };
            }
        }

        public LoadSourcesResult LoadSources(SourceControlVersion sourceControlVersion, string path)
        {
            NetworkCredential credentials = new NetworkCredential(
                        sourceControlVersion.SourceControl.GetStringProperty("Login"),
                        sourceControlVersion.SourceControl.GetStringProperty("Password"));

            try
            {
                using (SvnClient client = new SvnClient())
                {
                    client.LoadConfiguration(Path.Combine(Path.GetTempPath(), "Svn"), true);

                    client.Authentication.DefaultCredentials = credentials;

                    if (!Directory.Exists(path))
                    {
                        return this.LoadSourcesFromScratch(sourceControlVersion, path, client);
                    }

                    return this.LoadSourcesWithUpdate(sourceControlVersion, path, client);
                }
            }
            catch (SvnException e)
            {
                throw new AspNetDeployException("SvnClient failed to load sources", e);
            }
        }

        public LoadSourcesInfoResult LoadSourcesInfo(SourceControlVersion sourceControlVersion, string path)
        {
            NetworkCredential credentials = new NetworkCredential(
                sourceControlVersion.SourceControl.GetStringProperty("Login"),
                sourceControlVersion.SourceControl.GetStringProperty("Password"));

            Revision latestRevision =
                sourceControlVersion.Revisions.OrderByDescending(r => r.CreatedDate).FirstOrDefault();

            if (latestRevision == null)
            {
                return new LoadSourcesInfoResult
                {
                    SourcesInfos = new List<SourcesInfo>()
                };
            }

            SvnRevisionRange range = new SvnRevisionRange(long.Parse(latestRevision.Name), long.Parse(latestRevision.Name));

            if (latestRevision.ParentRevision != null)
            {
                range = new SvnRevisionRange(long.Parse(latestRevision.ParentRevision.Name) + 1, long.Parse(latestRevision.Name));
            }

            try
            {
                using (SvnClient client = new SvnClient())
                {
                    client.LoadConfiguration(Path.Combine(Path.GetTempPath(), "Svn"), true);

                    client.Authentication.DefaultCredentials = credentials;

                    Collection<SvnLogEventArgs> logEventArgs;

                    client.GetLog(path, new SvnLogArgs
                    {
                        Range = range
                    }, out logEventArgs);

                    return new LoadSourcesInfoResult
                    {
                        SourcesInfos = logEventArgs.Select(e => new SourcesInfo
                        {
                            CreatedDate = e.Time,
                            Author = e.Author,
                            Message = e.LogMessage
                        }).ToList()
                    };
                }
            }
            catch (SvnException e)
            {
                throw new AspNetDeployException("SvnClient failed to load sources", e);
            }
        }

        private LoadSourcesResult LoadSourcesWithUpdate(SourceControlVersion sourceControlVersion, string path, SvnClient client)
        {
            SvnUpdateResult result;

            try
            {
                client.Update(path, out result);
            }
            catch (SvnInvalidNodeKindException e)
            {
                Directory.Delete(path, true);
                return this.LoadSourcesFromScratch(sourceControlVersion, path, client);
            }
            catch (SvnWorkingCopyException e)
            {
                client.CleanUp(path);
                client.Update(path, out result);
            }

            SvnInfoEventArgs info;
            client.GetInfo(path, out info);

            return new LoadSourcesResult
            {
                RevisionId = info.LastChangeRevision.ToString(CultureInfo.InvariantCulture)
            };
        }

        private LoadSourcesResult LoadSourcesFromScratch(SourceControlVersion sourceControlVersion, string path, SvnClient client)
        {
            SvnUpdateResult result;
            Directory.CreateDirectory(path);

            string uriString = this.GetVersionURI(sourceControlVersion);

            client.CheckOut(new Uri(uriString), path, out result);

            SvnInfoEventArgs info;
            client.GetInfo(path, out info);

            return new LoadSourcesResult
            {
                RevisionId = info.LastChangeRevision.ToString(CultureInfo.InvariantCulture)
            };
        }

        public void Archive(SourceControlVersion sourceControlVersion, string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            this.DisableReadOnly(new DirectoryInfo(path));

            Directory.Delete(path, true);
        }

        private void DisableReadOnly(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directory.GetDirectories())
            {
                this.DisableReadOnly(subdirectory);
            }
        }

        private string GetVersionURI(SourceControlVersion sourceControlVersion)
        {
            return sourceControlVersion.SourceControl.GetStringProperty("URL").TrimEnd('/') + "/" + sourceControlVersion.GetStringProperty("URL")?.TrimStart('/');
        }
    }
}
