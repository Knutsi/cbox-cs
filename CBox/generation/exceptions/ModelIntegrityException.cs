using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cbox.generation
{
    public class ModelIntegrityException : Exception
    {
        public ModelIntegrityException(string msg) : base(msg)
        {

        }
    }

}
