using POCOi.Domain.OrdersContext.Queries;
using POCOi.Domain.OrdersContext.Repositories;
using POCOi.Infra.OrdersContext.DataContexts;
using POCOiNew.Domain.OrderContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using POCOi.Shared;

namespace POCOi.Infra.OrdersContext.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDataContext _context;

        public OrdersRepository(OrdersDataContext context)
        {
            _context = context;
        }

        public List<ListOrdersQueryResult> Get()
        {
            string cmdText = "select * from gerson.orders";
            List<ListOrdersQueryResult> orders = new List<ListOrdersQueryResult>();
            ListOrdersQueryResult newOrder;

            OracleConnection conn = new OracleConnection(Settings.ConnectionString);
            conn.Open();

            OracleCommand cmd = new OracleCommand(cmdText, conn);

            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newOrder = new ListOrdersQueryResult();
                newOrder.Order_Id = Convert.ToInt16(dr["Order_Id"]);
                newOrder.Customer_Id = Convert.ToInt16(dr["Customer_Id"]);
                newOrder.Status = Convert.ToString(dr["Status"]);
                if (dr["Salesman_Id"] != DBNull.Value)
                {
                    newOrder.Salesman_Id = Convert.ToInt16(dr["Salesman_Id"]);
                }
                else
                {
                    newOrder.Salesman_Id = 0;
                }
                newOrder.Order_Date = Convert.ToDateTime(dr["Order_Date"]);

                orders.Add(newOrder);
            }
            conn.Close();
            dr.Dispose();
            cmd.Dispose();
            conn.Dispose();

            return orders;
        }

        public Orders GetOrder(int orderId)
        {
            string cmdText = @"";

            return null;
        }

        public List<ListOfOrders> GetOrdersByStatus(string status)
        {
            List<ListOfOrders> orders = new List<ListOfOrders>();
            ListOfOrders newOrder;

            string sqlStatement = String.Join(" ", new string[]
            {
             "select order_id, customer_id, status, salesman_id,order_date from gerson.orders where status = :status"
            });

            using (OracleConnection conn = new OracleConnection(Settings.ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.BindByName = true;

                    cmd.CommandText = sqlStatement;

                    cmd.Parameters.Add(new OracleParameter("status", OracleDbType.NVarchar2));
                    // Gotcha #3 - see how the parameter name decoration (:) has been dropped 
                    // Gotcha #4 - the table definition is NUMBER(10,0) 
                    // but there is no Number in the OracleDbType enumeration.  
                    // You have to figure out what native .Net data type will fit the data without loss

                    cmd.Parameters[0].Value = status;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newOrder = new ListOfOrders();
                            newOrder.Order_Id = Convert.ToInt16(reader["Order_Id"]);

                            orders.Add(newOrder);
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                }
                return orders;
            }
        }

        public void Save(Orders oerders)
        {
            throw new NotImplementedException();
        }
    }
}
