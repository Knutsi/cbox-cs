using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation.nodetype
{
    public static class TypeHandlerLibrary
    {
        public static INodeType GetHandler(Node node) 
        {
            var type = node.Type;

            switch (type)
            {
                case BaseType.TYPE_IDENT:
                    return new BaseType() { Node = node };

                case Branch.TYPE_IDENT:
                    return new Branch() { Node = node };

                case SetValue.TYPE_IDENT:
                    return new SetValue() { Node = node };

                case ProblemStart.TYPE_IDENT:
                    return new ProblemStart() { Node = node };

                case ProblemEnd.TYPE_IDENT:
                    return new ProblemEnd() { Node = node };

                case Include.TYPE_IDENT:
                    return new Include() { Node = node };

                case Diagnosis.TYPE_IDENT:
                    return new Diagnosis() { Node = node };

                case Followup.TYPE_IDENT:
                    return new Followup() { Node = node };

                case Score.TYPE_IDENT:
                    return new Score() { Node = node };

                default:
                    throw new NoSuchHandlerException();
            }
        }

        public static List<string> TypeIdents
        {
            get
            {
                return new List<string> {
                    Branch.TYPE_IDENT, 
                    SetValue.TYPE_IDENT,
                    ProblemStart.TYPE_IDENT,
                    ProblemEnd.TYPE_IDENT,
                    Include.TYPE_IDENT,
                    Diagnosis.TYPE_IDENT,
                    Followup.TYPE_IDENT,
                    Score.TYPE_IDENT
                };
            }
        }
    }


    public class NoSuchHandlerException : Exception
    {
        public string MissingHandlerType;
    }
}
