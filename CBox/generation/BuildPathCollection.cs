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
        public BuildPathCollection Filter(List<string> include_tags, List<string> exclude_tags)
        {
            var filtered = new BuildPathCollection();

            // either include all, or only the ones selected:
            if (include_tags.Count == 0)
                filtered = this;
            else
                foreach (var tag in include_tags)
                    foreach (var path in this)
                        if (path.Tags.Contains(tag))
                            filtered.Add(path);

            // remove
            var to_remove = new List<BuildPath>();
            foreach (var tag in exclude_tags)
                foreach (var path in filtered)
                    if (path.Tags.Contains(tag))
                        to_remove.Add(path);

            foreach (var path in to_remove)
                filtered.Remove(path);

            return filtered;
        }
    }
}
