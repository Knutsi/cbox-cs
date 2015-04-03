using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cbox.modelling.setter_editors
{
    public enum StringEditorStringEntryMode
    {
        OLD, NEW   
    }

    public delegate void DeleteClickedEvent();
    public delegate void NewStringAdded();

    public partial class StringEditorStringEntry : UserControl
    {
        public event DeleteClickedEvent DeleteClicked;
        public event NewStringAdded NewStringAdded;

        private StringEditorStringEntryMode _Mode;

        public StringEditorStringEntry()
        {
            InitializeComponent();

            // send delete event when clicked:
            deleteButton.Click += (object o, EventArgs e) => 
            {
                if (DeleteClicked != null) 
                    DeleteClicked();
            };

            // if unused before, we need to switch mode when string is added:
            stringInput.TextChanged += (object o, EventArgs e) =>
            {
                if (Mode == StringEditorStringEntryMode.NEW)
                    Mode = StringEditorStringEntryMode.OLD;
            };
        }

        public string String
        {
            get
            {
                return stringInput.Text;
            }

            set
            {
                stringInput.Text = value;
            }
        }

        public StringEditorStringEntryMode Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                var old_mode = Mode;
                _Mode = value;

                
                // switch depending on button:
                switch (value)
                {
                    case StringEditorStringEntryMode.OLD:
                        deleteButton.Enabled = true;
                        break;

                    case StringEditorStringEntryMode.NEW:
                        deleteButton.Enabled = false;
                        break;

                    default:
                        break;
                }

                // fire event when going from new to old:
                if (old_mode == StringEditorStringEntryMode.NEW && Mode == StringEditorStringEntryMode.OLD)
                    if (NewStringAdded != null)
                        NewStringAdded();
            }
        }
    }
}
