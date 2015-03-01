using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    public class BuildPathCollection : List<BuildPath>
    {
        public NodeCollection ParentNodeCollection;

        /// <summary>
        /// Adds a BuildPath and ensures the collection gets set as it's parent.
        /// </summary>
        /// <param name="path"></param>
        public void Add(BuildPath path) 
        {
            path.ParentPathCollection = this;
            ((List<BuildPath>)this).Add(path);
        }
    }
}
