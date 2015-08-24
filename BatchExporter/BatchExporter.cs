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
        public bool RethrowExceptions { get; set; }


        public BatchExporter(string systemPath, string servicePath, int caseCount, bool rethrow)
        {
            this.SystemPath = systemPath;
            this.ServicePath = servicePath;
            this.CaseCount = caseCount;
            this.RethrowExceptions = rethrow;
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

                var casedir_path = Path.Combine(dirinfo.FullName, BatchExporter.CASE_DIR_NAME);
                var casedir = new DirectoryInfo(casedir_path);
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
            var backupdir_path = Path.Combine(this.ServiceDirInfo.FullName, backupdir_name);
            var backupdir = Directory.CreateDirectory(backupdir_path);
            if (!backupdir.Exists)
                throw new Exception("Could not create backup dir at " + backupdir_path);

            if (Backup)
            {
                Log("Moving old case files to " + backupdir.FullName);
                foreach (var file in CaseDirInfo.GetFiles())
                {
                    // make sure we dont move anyting by accident..
                    if(file.Name.EndsWith(".json"))
                        file.MoveTo(backupdir.FullName);

                }
            }
            else
            {
                Log("Deleting old case files");
                foreach (var file in CaseDirInfo.GetFiles())
                {
                    // make sure we dont kill anyting by accident..
                    if (file.Name.EndsWith(".json"))
                        file.Delete();
                }
            }

            Log("CleanCaseDir() done");
        }


        private void ExportOntology()
        {
            

            var ontology = CBoxSystem_.Ontology;
            var clipack_text = ontology.ExportClientPackageString();
            var clipack_path = Path.Combine(ServiceDirInfo.FullName, BatchExporter.CLIENT_PACKAGE_NAME);
            Log("Exporting client package to "+ clipack_path);

            File.WriteAllText(clipack_path, clipack_text);

            Log("ExportOntology() done");
        }


        private void GenerateCases()
        {
            Log("Exporting cases");

            var count = 0;
            foreach (var modelref in CBoxSystem_.Models)
            {
                var model_xml = File.ReadAllText(modelref.Path);
                var model = Model.FromXML(model_xml);

                // generate the number of cases we want:
                for (int i = 0; i < CaseCount; i++)
                {
                    // generate the case:
                    var case_ = model.RandomCase(CBoxSystem_);

                    // expand the case with all possible values:
                    var errors = new List<string>();
                    CBoxSystem_.Ontology.ExpandCompletely(case_, errors, RethrowExceptions);
                    foreach (var error in errors)
                        Log(error);

                    // write case as JSON:
                    var path = Path.Combine(ServiceDirInfo.FullName, BatchExporter.CASE_DIR_NAME, count + ".json");
                    File.WriteAllText(path, case_.toJSON());

                    Log(string.Format("{0} ({1} of {2}) exported to: {3}", count, i, CaseCount, path));

                    count++;
                }
            }

            Log("Saving manifesto");
            var manifesto = new ExportManifesto() { CaseCount = count };
            var manifesto_path = Path.Combine(ServiceDirInfo.FullName, BatchExporter.CASE_DIR_NAME, "manifesto.json");
            File.WriteAllText(manifesto_path, manifesto.toJSON());
        }

   
    }
}
