using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation.setter;


namespace cbox.modelling.setter_editors
{
    /// <summary>
    /// The interface that the app uses to the editor.  The editor gets
    /// </summary>
    public interface ISetterEditor
    {
        void SaveData();
        string SetterXmlData { get; set; }
    }
}
