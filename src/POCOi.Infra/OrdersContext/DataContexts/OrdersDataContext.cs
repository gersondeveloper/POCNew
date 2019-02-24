using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using POCOi.Shared;
using Oracle.ManagedDataAccess.Client;

namespace POCOi.Infra.OrdersContext.DataContexts
{
     public class OrdersDataContext : IDisposable
        {
            public OracleConnection Connection { get; set; }

            public OrdersDataContext()
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