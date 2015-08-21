using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using cbox.model;
using cbox.generation;
using cbox.system;

namespace BatchExporter
{
    public enum ExporterStatus {
        IDLE,
        RUNNING
    }

    public class BatchExporter
    {
        public static string CASE_DIR_NAME = "case";
        public static string OLD_CASE_DIR_NAME = "old cases";
        public static string CLIENT_PACKAGE_NAME = "clientpackage.json";

        public ExporterStatus State = ExporterStatus.IDLE;

        private DirectoryInfo ServiceDirInfo;
        private DirectoryInfo CaseDirInfo;
        private CBoxSystem CBoxSystem_;

        public List<string> MessageLog = new List<string>();
        
        public int CaseCount { get; set; }
        public bool Backup { get; set; }

        public BatchExporter(string systemPath, string servicePath, int caseCount)
        {
            this.SystemPath = systemPath;
            this.ServicePath = servicePath;
            this.CaseCount = caseCount;
        }

        /// <summary>
        /// Runs the export procedure.
        /// </summary>
        public void RunExport()
        {
            Log("-- Running export --");
            var start_time = DateTime.Now;

            if (State == ExporterStatus.RUNNING)
                throw new Exception("Export process already running");
            
            // set state to running:
            State = ExporterStatus.RUNNING;

            // clean service directory:
            CleanCaseDir();
            ExportOntology();
            GenerateCases();

            var end_time = DateTime.Now;
            var time = (end_time - start_time).TotalSeconds;

            Log("-- Run done in " + time + " seconds");
        }


        private void Log(string msg)
        {
            Console.WriteLine(msg);
            MessageLog.Add(msg);
        }


        public string SystemPath
        {
            get {
                if (this.CBoxSystem_ != null)
                    return this.CBoxSystem_.Path;
                else
                    return null;
            }

            set
            {
                this.CBoxSystem_ = new CBoxSystem(value);
            }
        }


        public string ServicePath {
            get
            {
                if (this.ServiceDirInfo != null)
                    return this.ServiceDirInfo.FullName;
                else
                    return null;
            }

            set
            {
                var dirinfo = new DirectoryInfo(value);
                if (!dirinfo.Exists)
                    throw new Exception("Service directory does not exist at {0}" + value);

                var casedir = new DirectoryInfo(dirinfo.FullName + BatchExporter.CASE_DIR_NAME);
                if (!casedir.Exists)
                    throw new Exception(string.Format("Service dir does not contain a '{0}' directory", BatchExporter.CASE_DIR_NAME));

                this.ServiceDirInfo = dirinfo;
                this.CaseDirInfo = casedir;
            }

        }

        /// <summary>
        /// Cleans out the old cases from the case directory, and backs them up to a new folder
        /// </summary>
        private void CleanCaseDir()
        {
            // move all files in case direcotyr a backup dir:
            var backupdir_name = string.Format("backup-{0}", DateTime.Today.Millisecond);
            var backupdir_path = this.ServiceDirInfo.FullName + backupdir_name;
            var backupdir = Directory.CreateDirectory(backupdir_path);
            if (!backupdir.Exists)
                throw new Exception("Could not create backup dir at " + backupdir_path);

            if (Backup)
            {
                Log("Moving old case files to " + backupdir.FullName);
                foreach (var file in CaseDirInfo.GetFiles())
                    file.MoveTo(backupdir.FullName);
            }
            else
            {
                Log("Deleting old case files");
                foreach (var file in CaseDirInfo.GetFiles())
                    file.Delete();
            }

            Log("CleanCaseDir() done");
        }


        private void ExportOntology()
        {
            Log("Exporting client package");

            var ontology = CBoxSystem_.Ontology;
            var clipack_text = ontology.ExportClientPackageString();
            var clipack_path = CBoxSystem_.Path + "\\" + BatchExporter.CLIENT_PACKAGE_NAME;

            File.WriteAllText(clipack_path, clipack_text);

            Log("ExportOntology() done");
        }


        private void GenerateCases()
        {
            Log("Exporting cases");

            var count = 0;
            foreach (var modelref in CBoxSystem_.Models)
            {
                var model = Model.FromXML(modelref.Path);

                // generate the number of cases we want:
                for (int i = 0; i < CaseCount; i++)
                {
                    var case_ = model.RandomCase();
                    var path = Path.Combine(ServiceDirInfo.FullName, BatchExporter.CASE_DIR_NAME, i + ".json");
                    File.WriteAllText(path, case_.toJSON());

                    Log(string.Format("{0} ({1} of {2}) exported to: {3}", count, i, CaseCount, path));

                    count++;
                }
            }
        }

   
    }
}
