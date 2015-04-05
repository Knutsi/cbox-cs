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
    public partial class RangeEditor : UserControl, ISetterEditor
    {
        private RangeSetterData _SetterData = null;

        public RangeEditor()
        {
            InitializeComponent();
            disttributionPicker.SelectedIndex = 0;

            rangeInput.TextChanged += (object o, EventArgs e) => { SaveData(); };
        }

        public void LoadData()
        {
            if (_SetterData == null)
                return;

            rangeInput.Text = string.Format("{0} - {1}", _SetterData.Min, _SetterData.Max);
        }

        /// <summary>
        /// Tries to parse the input field and store the data.
        /// </summary>
        public void SaveData()
        {
            if (_SetterData == null)
                _SetterData = new RangeSetterData();

            // parse the input:
            var split_input = rangeInput.Text.Split('-');
            if(split_input.Length == 2)
            {
                var data = _SetterData as RangeSetterData;

                try
                {
                    data.Min = double.Parse(split_input[0].Trim());
                    data.Max = double.Parse(split_input[1].Trim());
                    rangeInput.BackColor = SystemColors.ControlLight;
                }
                catch
                {
                    rangeInput.BackColor = Color.LightPink;
                    data.Min = 0;
                    data.Max = 0;
                }
            }
            
            
        }

        public string SetterXmlData
        {
            get
            {
                if (_SetterData != null)
                    return _SetterData.ToXML();
                else
                    return (new RangeSetterData()).ToXML();
            }
            set
            {
                if (value != null)
                    _SetterData = RangeSetterData.FromXML(value);
                
                LoadData();
            }
        }

    }
}
