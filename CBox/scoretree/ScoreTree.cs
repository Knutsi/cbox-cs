using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.scoretree
{
    public class ScoreTree : List<ConsequenceNode>
    {

        public void Merge(ScoreTree tree)
        {
            foreach (var cnode in tree)
            {
                this.Add(cnode);
            }
        }


        /// <summary>
        /// Calculates the result of the tree.
        /// </summary>
        public Result Result
        {

            get
            {
                var result = new Result();
                /* We will not evaluate the child nodes.  We will add scores of all positive points nodes,
                see if we have any fails */
                foreach (var conseq_node in this)
                {
                    result.Score += conseq_node.Points;
                    result.MaxScore += conseq_node.MaxPoints;
                    if (conseq_node.Fail)
                        result.Failed = true;

                    result.Comments.AddRange(conseq_node.Comments);
                }



                // and done:
                return result;
            }
        }

        public List<object> Objects
        {
            set
            {
                foreach (var conseq_node in this)
                    conseq_node.Objects = value;
            }

        }


    }
}
