﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cbox.generation;

namespace cbox.modelling.editors
{
    public interface IInnerEditor
    {
        Node Node { set; }
        NodeEditor ParentEditor { get; set; }
        void OnOuterEditorClosing();
    }
}
