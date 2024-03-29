﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using cbox.model;
using cbox.generation.setter;

namespace OntologyEditor
{
    /// <summary>
    /// Special class to import tabular data into ontology. 
    /// </summary>
    public class TabularDataTestImporter
    {
        private Ontology Ontology;
        public List<string> ImportLog;
        public int Errors = 0;

        public TabularDataTestImporter(Ontology ontology)
        {
            this.Ontology = ontology;
        }

        /// <summary>
        /// Takes a set of tabular data and imports it. 
        /// </summary>
        /// <param name="rows"></param>
        public void Import(DataTable table)
        {
            ImportLog = new List<string>() { "Import start" };

            DoPreImportChecks(table);

            ImportTests(table);
            ImportActions(table);
            ImportCategories(table);
            ImportShorthand(table);
            ImportClasses(table);

            ImportLog.Add("Import complete");
        }


        private void DoPreImportChecks(DataTable table)
        {
            Check_ActionClassCount(table);
        }

        /// <summary>
        /// Checks if all action entries have a corresponding number of action entries.
        /// </summary>
        private void Check_ActionClassCount(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var action_count = row["Action"].ToString().Split(';').Count();
                var classes_count = row["ActionClasses"].ToString().Split(';').Count();

                if(action_count != classes_count)
                {
                    this.Errors += 1;
                    this.ImportLog.Add(string.Format("{0}: Action and class count mismatch", row["Key"].ToString()));
                }
            }
        }


        private void ImportTests(DataTable table)
        {
            // process each row
            foreach (DataRow row in table.Rows)
            {
                // get or create test, then fill with data:
                var test = GetOrAddTest(row["Key"].ToString());
                test.Title = row["Title"].ToString();
                test.Datatype = row["Datatype"].ToString();
                test.SetterIdent = row["Setter"].ToString();
                test.Unit = row["Unit"].ToString();
                test.Accumulative = row["Accumulative"].ToString() == "yes";
                test.ParentKey = row["ParentKey"].ToString();

                // decimals:
                if (row["Decimals"] != null && row["Decimals"] != "")
                    test.Decimals = Convert.ToInt32(row["Decimals"].ToString());

                // dependencies:
                test.Dependencies = (
                    from d in row["Dependencies"].ToString().Split(';') 
                    where d.Trim() != string.Empty
                    select d.Trim()
                    ).ToList(); 

                // prefix:
                if (test.Prefix != null && test.Prefix.Trim() == string.Empty)
                    test.Prefix = null;

                // copy or add prefix:
                var prefix = row["Prefix"].ToString();
                if (prefix == "(copy)")
                    test.Prefix = test.Title;
                else
                    test.Prefix = prefix;
            }
        }


        private void ImportActions(DataTable table)
        {
            /* Actions are separated by ;, while classes for actions are by ; and then , for each class
             General, Swabbable;Emesis
             */

            foreach (DataRow row in table.Rows)
            {
                // split actions and assign classes:
                var actions = row["Action"].ToString().Split(';');
                var action_classes = row["ActionClasses"].ToString().Split(';');    // action-classes split by ;
                for (var i = 0; i < actions.Count(); i++ )
                {
                    // create action - generate title if requested:
                    var title = actions[i];
                    if (title == "(generate)")
                        title = row["Title"].ToString();

                    var action = GetOrAddAction(title);
                    action.Title = title;

                    // get classes
                    var classes = action_classes[i].Split(','); // classes in each action split by ,
                    foreach (var class_ in classes)
                    {
                        var class_str = class_.Trim();
                        if (!action.TargetClasses.Contains(class_str))
                            action.TargetClasses.Add(class_str);
                    }

                    // assign key as yield to this action:
                    var key = row["Key"].ToString();
                    if (!action.Yield.Contains(key))
                        action.Yield.Add(key);

                    if (key.Trim() != string.Empty)
                    {
                        // set flag for visible headline hit (used in case rendering if context is needed for yield):
                        action.VisibleHeadlineHint = row["VisibleHeadlineHint"].ToString() == "yes";

                        // import time, risk, pain, money:
                        action.Time = Int32.Parse(row["Time"].ToString());
                        action.Risk = double.Parse(row["Risk"].ToString());
                        action.Pain = double.Parse(row["Pain"].ToString());
                        action.Money = Int32.Parse(row["Money"].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Imports the categorization of actions into forms and headlines.
        /// </summary>
        /// <param name="table"></param>
        private void ImportCategories(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                // get and split the categories and actions:
                var categories = row["Category"].ToString().Split(';');
                var subcategories = row["Sub-category"].ToString().Split(';');
                var actions = row["Action"].ToString().Split(';'); 

                // check that required data exists:
                if (row["Action"].ToString().Trim() == string.Empty 
                    || row["Category"].ToString().Trim() == string.Empty)
                {
                    continue;
                }
                   
                for (int i = 0; i < categories.Count(); i++)
                {
                    // get category, subcategory and action title:
                    var category_title = categories[i];
                    var subcategory_title = subcategories[i];
                    var action_title = actions[i];
                    if (action_title == "(generate)")
                        action_title = row["Title"].ToString();


                    var form = GetOrAddForm(category_title);
                    var headline = GetOrAddHeadline(form, subcategory_title);
                    var action = Ontology.ActionByTitle(action_title);

                    if (action == null)
                        throw new Exception(string.Format("Error - action missing when importing category: {0}", action_title));
                
                    // add action to headline:
                    if (!headline.ActionIdents.Contains(action.Ident))
                        headline.ActionIdents.Add(action.Ident);
                }

                
            }
        }

        /// <summary>
        /// Imports shorthand data. Shorthand data is set as semi-colo-separated commands that 
        /// setter data classes can parse.  They are fed in sequence by this command.
        /// </summary>
        /// <param name="table"></param>
        public void ImportShorthand(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var shorthand = row["Shorthand"].ToString();
                /*if (shorthand == string.Empty)
                    continue;*/

                // grab relevant test:
                var test = Ontology.TestByKey(row["Key"].ToString());
                if (test.Key == string.Empty)
                    continue;   // skip blank lines

                // get setter:
                var setter = SetterLibrary.Default[test.SetterIdent];
                if (setter == null)
                    throw new Exception(string.Format("Could not find setter '{0}'", test.SetterIdent));

                // parse shorthand commands:
                var cmds = (from c in shorthand.Split(';')
                            where c != string.Empty
                            select new ShorthandCommand(c)).ToList();

                // grab a shorthand reader from the setter type:
                switch (test.SetterIdent)
                {
                    case "STRING":
                        test.SetterXMLData = this.StringDataFromShorthand(cmds);
                        break;

                    case "RANGE":
                        test.SetterXMLData = this.RangeDataFromShorthand(cmds);
                        break;

                    case "MRANGE":
                        test.SetterXMLData = this.MultiRangeDataFromShorthand(cmds);
                        break;

                    case "MSTRING":
                        test.SetterXMLData = this.MultiStringDataFromShorthand(cmds);
                        break;

                    default:
                        break;
                }
            }    
        }


        public void ImportClasses(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var ident = row["ActionClasses"].ToString();
                //var ident = name.ToLower();

                var problem = Ontology.ClassByIdent(ident);
                if (problem != null || ident.Trim() == string.Empty)
                    continue;

                // add class:
                Ontology.AddClass(ident);
            }

        }


        private string MultiRangeDataFromShorthand(List<ShorthandCommand> cmds)
        {
            var data = new MultiRangeSetterData();

            // format of AR-commands: AR:F00-13: 11.0-15.0
            foreach (var cmd in cmds)
            {
                // each AR-command means a
                if(cmd.Command == "AR" && cmd.AR_Params.Valid)
                {
                    var param = cmd.AR_Params;
                    var range = new MultiRangeSetterDataEntry()
                    {
                        AgeStart = param.AgeStart,
                        AgeEnd = param.AgeEnd,
                        Min = param.ValueStart,
                        Max = param.ValueEnd,
                        Gender = param.Gender
                    };

                    data.Ranges.Add(range);
                }
            }

            return data.ToXML();
        }

        private string MultiStringDataFromShorthand(List<ShorthandCommand> cmds)
        {
            var data = new MultiStringSetterData();

            // format of AMS-commands: AR:F00-13:<VALUE>
            foreach (var cmd in cmds)
            {
                // each AR-command means a
                if (cmd.Command == "AMS" && cmd.AMS_Params.Valid)
                {
                    var param = cmd.AMS_Params;
                    var range = new MultiStringSetterDataEntry()
                    {
                        AgeStart = param.AgeStart,
                        AgeEnd = param.AgeEnd,
                        Value = param.Value,
                        Gender = param.Gender
                    };

                    data.Ranges.Add(range);
                }
            }

            return data.ToXML();
        }


        private string RangeDataFromShorthand(List<ShorthandCommand> cmds)
        {
            var data = new RangeSetterData();

            foreach (var cmd in cmds)
            {
                if(cmd.Command == "R")
                {
                    if (!cmd.R_Params.Valid)
                        throw new Exception("Invalid R command in shorthand");

                    data.Min = cmd.R_Params.ValueStart;
                    data.Max = cmd.R_Params.ValueEnd;
                }
            }

            return data.ToXML();
        }

        private string StringDataFromShorthand(List<ShorthandCommand> cmds)
        {
            var data = new StringSetterData();

            foreach (var cmd in cmds)
            {
                if (cmd.Command == "AS")
                    data.Strings.Add(cmd.AS_Params.StringText);
            }

            return data.ToXML();
        }


        /// <summary>
        /// Looks up a test in the ontology.  If not found, it gets added.
        /// The test is then returned. 
        /// </summary>
        /// <param name="key"></param>
        private Test GetOrAddTest(string key)
        {
            var test = this.Ontology.TestByKey(key);
            if(test == null)
            {
                test = new Test() { Key = key };
                this.Ontology.AddTest(test);
            }

            return test;
        }

        /// <summary>
        /// Looks up a action by it't title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private cbox.model.Action GetOrAddAction(string title)
        {
            var action = this.Ontology.ActionByTitle(title);
            if(action == null)
            {
                action = new cbox.model.Action();
                this.Ontology.AddAction(action);
            }

            return action;
        }


        private cbox.model.Form GetOrAddForm(string title)
        {
            var form = Ontology.FormByTitle(title);
            if (form == null)
            {
                form = new cbox.model.Form() { Title = title };
                this.Ontology.AddForm(form);
            }

            return form;
        }


        private Headline GetOrAddHeadline(cbox.model.Form form, string title)
        {
            Headline headline = null;
            foreach (var existing_headline in form.Headlines)
                if (existing_headline.Title == title)
                    headline = existing_headline;

            if (headline == null)
                headline = form.AddHeadline(title);

            return headline;
        }



    }
}
