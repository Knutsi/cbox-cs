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

                case NOff.TYPE_IDENT:
                    return new NOff() { Node = node };

                case SetValue.TYPE_IDENT:
                    return new SetValue() { Node = node };

                case ProblemStart.TYPE_IDENT:
                    return new ProblemStart() { Node = node };

                case ProblemEnd.TYPE_IDENT:
                    return new ProblemEnd() { Node = node };

                default:
                    throw new NoSuchHandlerException();
            }
        }
    }


    public class NoSuchHandlerException : Exception
    {
        public string MissingHandlerType;
    }
}
