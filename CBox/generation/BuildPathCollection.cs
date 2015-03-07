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
        public new void Add(BuildPath path) 
        {
            path.ParentPathCollection = this;
            ((List<BuildPath>)this).Add(path);
        }

        /// <summary>
        /// Get the selection of build paths in the collection that fullfills the criteria 
        /// provided.
        /// </summary>
        /// <returns></returns>
        public BuildPathCollection Filter()
        {
            throw new NotImplementedException();
        }
    }
}
