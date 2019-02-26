using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using POCOi.Shared;
using Oracle.ManagedDataAccess.Client;

namespace POCOi.Infra.OfertasContext.DataContexts
{
     public class OfertasDataContext : IDisposable
        {
            public OracleConnection Connection { get; set; }

            public OfertasDataContext()
            {
                Connection = new OracleConnection(Settings.ConnectionString);
                Connection.Open();
            }

            public void Dispose()
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
        }
    }