using POCOi.Domain.OrdersContext.Queries;
using POCOiNew.Domain.OrderContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POCOi.Domain.OrdersContext.Repositories
{
    public interface IOrdersRepository
    {
        void Save(Orders oerders);
        List<ListOrdersQueryResult> Get();
        Orders GetOrder(int orderId);
        List<ListOfOrders> GetOrdersByStatus(string status);
    }
}
