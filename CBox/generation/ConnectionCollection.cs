using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.generation
{
    public class ConnectionCollection : List<Connection>
    {
        public ConnectionCollection From(Node n)
        {
            var result = new ConnectionCollection();
            foreach (var connection in this)
                if (connection.FromNode == n)
                    result.Add(connection);

            return result;
        }

        public ConnectionCollection To(Node n)
        {
            var result = new ConnectionCollection();
            foreach (var connection in this)
                if (connection.ToNode == n)
                    result.Add(connection);

            return result;
        }
    }
}
