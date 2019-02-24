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
            ListOrdersQueryResult newOrder ;
            int finalResult;

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

        public GetOrderQueryResult GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListOrdersQueryResult> GetOrdersByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public void Save(Orders oerders)
        {
            throw new NotImplementedException();
        }
    }
}
