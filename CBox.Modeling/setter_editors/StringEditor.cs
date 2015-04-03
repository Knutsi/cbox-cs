using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation.setter;

namespace cbox.modelling.setter_editors
{
    public partial class StringEditor : UserControl, ISetterEditor
    {
        private StringSetterData Data;

        public StringEditor()
        {
            InitializeComponent();

            //this.Height = 400;
        }

        public void SaveData()
        {
            Data = new StringSetterData();

            // extract strings:
            Data.Strings = (from e in StringEditors
                            where e.String != string.Empty && e.Mode == StringEditorStringEntryMode.OLD
                            select e.String).ToList();

            Data.Thesaurus = (from e in ThesaurusEditors
                              where 
                                  e.ThesaurusEntry.Word != string.Empty
                                  && e.ThesaurusEntry.Synonyms.Count > 0
                                  && e.Mode == StringEditorThesaurusEntryMode.OLD
                              select e.ThesaurusEntry).ToList();

        }


        /// <summary>
        /// This controls uses it's internal control higerarchy to 
        /// </summary>
        public void LoadData()
        {
            // STRINGS: 
            foreach (var string_ in Data.Strings)
            {
                var string_editor = new StringEditorStringEntry() { String = string_ };
                stringFlowLayout.Controls.Add(string_editor);

                // if the delete button is clicked, we remove the editor:
                string_editor.DeleteClicked += () =>
                {
                    stringFlowLayout.Controls.Remove(string_editor);
                };
            }

            // add a editor in new string mode to enable adding new strings:
            AddNewStringInputControl();

            // THESAURUS:
            foreach (var entry in Data.Thesaurus)
            {
                var thes_editor = new StringEditorThesaurusEntry() { ThesaurusEntry = entry };
                thesaurusFlow.Controls.Add(thes_editor);

                thes_editor.Deleted += () =>
                { 
                    thesaurusFlow.Controls.Remove(thes_editor); 
                };
            }

            AddNewThesaurusEntryControl();
        }


        /// <summary>
        /// Adds a new emptry string editor set to new mode, and register an event listener 
        /// to detect when new strings are added.
        /// </summary>
        public void AddNewStringInputControl()
        {
            var editor = new StringEditorStringEntry() { Mode = StringEditorStringEntryMode.NEW };
            stringFlowLayout.Controls.Add(editor);

            // if it becomes used, we need to add a new editor below it:
            editor.NewStringAdded += () =>
            {
                AddNewStringInputControl();
            };

            // register delete handler:
            editor.DeleteClicked += () =>
            {
                stringFlowLayout.Controls.Remove(editor);
            };
        }

        public void AddNewThesaurusEntryControl()
        {
            var editor = new StringEditorThesaurusEntry() { Mode = StringEditorThesaurusEntryMode.NEW };
            thesaurusFlow.Controls.Add(editor);

            editor.NewCreated += () =>
            {
                AddNewThesaurusEntryControl();
            };

            editor.Deleted += () =>
            {
                thesaurusFlow.Controls.Remove(editor);
            };
                
        }


        /// <summary>
        /// Casts all controls in the string flow layout as StringEditorStringEntry
        /// and returns the list.
        /// </summary>
        private List<StringEditorStringEntry> StringEditors 
        {
            get
            {
                var list = new List<StringEditorStringEntry>();

                foreach (var ctrl in stringFlowLayout.Controls)
                    list.Add((StringEditorStringEntry)ctrl);

                return list;
            }
        }


        /// <summary>
        /// Casts all controls in the string flow layout as StringEditorStringEntry
        /// and returns the list.
        /// </summary>
        private List<StringEditorThesaurusEntry> ThesaurusEditors
        {
            get
            {
                var list = new List<StringEditorThesaurusEntry>();

                foreach (var ctrl in thesaurusFlow.Controls)
                    list.Add((StringEditorThesaurusEntry)ctrl);

                return list;
            }
        }

        public string SetterXmlData
        {
            get
            {
                SaveData();
                return Data.ToXML();
            }
            set
            {
                Data = StringSetterData.FromXML(value);
                LoadData();
            }
        }

    }
}
