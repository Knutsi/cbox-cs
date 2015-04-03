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
    public enum StringEditorThesaurusEntryMode
    {
        OLD, NEW
    }

    public delegate void NewThesaurusEntry();

    public partial class StringEditorThesaurusEntry : UserControl
    {
        public event DeleteClickedEvent Deleted;
        public event NewThesaurusEntry NewCreated;

        private StringEditorThesaurusEntryMode _Mode;

        public StringEditorThesaurusEntry()
        {
            InitializeComponent();

            deleteButton.Click += (object s, EventArgs e) =>
            {
                if (Deleted != null) 
                    Deleted();
            };

            wordEntry.TextChanged += (object s, EventArgs e) =>
            {
                if (Mode == StringEditorThesaurusEntryMode.NEW)
                    Mode = StringEditorThesaurusEntryMode.OLD;
            };

            synonymEntry.TextChanged += (object s, EventArgs e) =>
            {
                if (Mode == StringEditorThesaurusEntryMode.NEW)
                    Mode = StringEditorThesaurusEntryMode.OLD;
            };
        }

        /// <summary>
        /// Generates a thesaurus entry based on the data in the form fields.
        /// </summary>
        public ThesaurusEntry ThesaurusEntry
        {
            get
            {
                var entry = new ThesaurusEntry()
                {
                    Word = wordEntry.Text,
                    Synonyms = (from s in synonymEntry.Text.Split(',')
                                select s.Trim()).ToList()
                };

                return entry;
            }

            set
            {
                wordEntry.Text = value.Word;
                synonymEntry.Text = string.Join(", ", value.Synonyms);
            }
        }

        public StringEditorThesaurusEntryMode Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                var old_mode = Mode;
                _Mode = value;

                // change GUI depeding on mode (new items cannot be deleted)
                switch (Mode)
                {
                    case StringEditorThesaurusEntryMode.OLD:
                        deleteButton.Enabled = true;
                        break;

                    case StringEditorThesaurusEntryMode.NEW:
                        deleteButton.Enabled = false;
                        break;

                    default:
                        break;
                }

                // if we have a mode switch, we need to signal this:
                if (old_mode == StringEditorThesaurusEntryMode.NEW && Mode == StringEditorThesaurusEntryMode.OLD)
                    if (NewCreated != null)
                        NewCreated();
            }
        }
    }
}
