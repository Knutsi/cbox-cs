﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public class IncludeData : XMLSerializable<IncludeData>, INodeTypeData
    {
        public List<OutputSocket> OuputSockets = new List<OutputSocket>();

        //public IncludeSource Source { get; set; }
        //public string NodeCollectionIdent { get; set; }
        public List<IncludeDataEntry> Includes = new List<IncludeDataEntry>();
        public List<string> ExcludeTags = new List<string>();
        public List<string> IncludeTags = new List<string>();

        public IncludeDataEntry EntryByIdentAndLocalStatus(string ident, bool local)
        {
            foreach (var entry in Includes)
                if (entry.Local == local && entry.Ident == ident)
                    return entry;

            return null;
        }
    }
}
