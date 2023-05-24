using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace DataAccess
{
    public abstract class Connection
    {

        private readonly string connectionString;
        public Connection()
        {
            connectionString = "DATA SOURCE = XE; PASSWORD = IMAGINA; USER ID = IMAGINA";
        }

        protected OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }

    }
}
