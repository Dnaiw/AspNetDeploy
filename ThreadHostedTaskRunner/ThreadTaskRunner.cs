﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetDeploy.Contracts;
using AspNetDeploy.Model;
using Microsoft.VisualBasic;

namespace ThreadHostedTaskRunner
{
    public class ThreadTaskRunner : ITaskRunner
    {
        private readonly Timer Timer = new Timer(TimerCallback);
        private static bool IsTimerRunning = false;

        public void Initialize()
        {
            Timer.Change(new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 30));
        }

        public void WatchForSources()
        {
        }

        public SourceControlState GetSourceControlState(int sourceControlId)
        {
            return TaskRunnerContext.GetSourceControlVersionState(sourceControlId);
        }

        public ProjectState GetProjectState(int projectId)
        {
            return TaskRunnerContext.GetProjectVersionState(projectId);
        }

        public BundleState GetBundleState(int bundleId)
        {
            return TaskRunnerContext.GetBundleVersionState(bundleId);
        }

        public void Shutdown()
        {
        }

        private static void TimerCallback(object state)
        {
            if (IsTimerRunning)
            {
                return;
            }

            IsTimerRunning = true;

            ProcessTasks();

            IsTimerRunning = false;
        }

        public static void ProcessTasks()
        {
            AspNetDeployEntities entities = new AspNetDeployEntities();

            TakeSources(entities);
            BuildProjects(entities);
            
        }

        private static void BuildProjects(AspNetDeployEntities entities)
        {
            List<BundleVersion> bundleVersions = entities.BundleVersion
                .Include("Bundle")
                .Include("ProjectVersions.SourceControlVersion")
                .Where( bv => bv.ProjectVersions.Any())
                .ToList();

            foreach (BundleVersion bundleVersion in bundleVersions)
            {
                TaskRunnerContext.SetBundleVersionState(bundleVersion.Id, BundleState.Building);

                foreach (var pair in bundleVersion.ProjectVersions.Select(pv => new { pv.SolutionFile, pv.SourceControlVersion }).Distinct())
                {
                    BuildProjectJob job = new BuildProjectJob();
                    job.Start(pair.SourceControlVersion.Id, pair.SolutionFile);
                }

                TaskRunnerContext.SetBundleVersionState(bundleVersion.Id, BundleState.Idle);
            }
        }

    /*    private static void ProcessProjects(AspNetDeployEntities entities)
        {
            List<Bundle> bundles = entities.Bundle
                .Include("Projects.SourceControl.Properties")
                .ToList();

            List<Project> projectsToBuild = new List<Project>();

            Parallel.ForEach(bundles, bundle =>
            {
                if (bundle.Projects.Any(p => TaskRunnerContext.GetProjectVersionState(p.Id) != ProjectState.Idle))
                {
                    return;
                }

                if (bundle.Projects.Any(p => TaskRunnerContext.GetSourceControlVersionState(p.SourceControl.Id) != SourceControlState.Idle))
                {
                    return;
                }

                if (TaskRunnerContext.GetBundleVersionState(bundle.Id) == BundleState.Idle)
                {
                    foreach (SourceControl sourceControl in bundle.Projects.Select( p => p.SourceControl))
                    {
                        if (sourceControl.GetStringProperty("Revision") != sourceControl.GetStringProperty("LastBuildRevision"))
                        {
                            foreach (Project project in sourceControl.Projects)
                            {
                                TaskRunnerContext.SetNeedToBuildProject(project.Id, true);
                            }
                        }
                    }

                    foreach (Project project in bundle.Projects.Where( p => TaskRunnerContext.GetNeedToBuildProject(p.Id)))
                    {
                        TaskRunnerContext.SetProjectVersionState(project.Id, ProjectState.QueuedToBuild);

                        foreach (Bundle projectBundle in project.Bundles)
                        {
                            TaskRunnerContext.SetBundleVersionState(projectBundle.Id, BundleState.BuildQueued);
                        }

                        projectsToBuild.Add(project);
                    }
                }
            });*/
/*
            var pairs = projectsToBuild.Select(p => new {p.SourceControl, p.SolutionFile, p.Bundles}).Distinct().ToList();

            foreach (var pair in pairs)
            {
                BuildProjectJob job = new BuildProjectJob();
                job.Start(pair.SourceControl.Id, pair.SolutionFile);

                foreach (Bundle bundle in pair.Bundles)
                {
                    TaskRunnerContext.SetBundleVersionState(bundle.Id, BundleState.Building);
                }
            }
        }
*/
        private static void TakeSources(AspNetDeployEntities entities)
        {
            List<SourceControlVersion> sourceControlVersions = entities.SourceControlVersion
                .Include("ProjectVersions")
                .Include("Properties")
                .Include("ProjectVersions.BundleVersions")
                .Include("SourceControl.Properties")
                .ToList();

            IList<BundleVersion> bundleVersions = sourceControlVersions.SelectMany( scv => scv.ProjectVersions).SelectMany( pv => pv.BundleVersions).ToList();

            foreach (BundleVersion bundleVersion in bundleVersions)
            {
                TaskRunnerContext.SetBundleVersionState(bundleVersion.Id, BundleState.Loading);
            }

            Parallel.ForEach(sourceControlVersions, sourceControlVersion =>
            {
                TaskRunnerContext.SetSourceControlVersionState(sourceControlVersion.Id, SourceControlState.Loading);

                try
                {
                    (new SourceControlJob(sourceControlVersion.Id)).Start();
                    TaskRunnerContext.SetSourceControlVersionState(sourceControlVersion.Id, SourceControlState.Idle);
                }
                catch (Exception e)
                {
                    TaskRunnerContext.SetSourceControlVersionState(sourceControlVersion.Id, SourceControlState.Error);
                }
            });

            foreach (BundleVersion bundleVersion in bundleVersions)
            {
                TaskRunnerContext.SetBundleVersionState(bundleVersion.Id, BundleState.Idle);
            }
        }

    }
}