using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox;
using cbox.model;

namespace ModelEditor.support
{
    public class SavedLimitSetCollection : XMLSerializable<SavedLimitSetCollection>
    {
        public List<SavedLimitSet> Sets = new List<SavedLimitSet>();
    }
}
