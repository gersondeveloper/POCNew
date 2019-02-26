using POCOi.Domain.OrdersContext.Queries;
using POCOi.Domain.OfertasContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POCOi.Domain.OfertasContext.Repositories
{
    public interface IOfertasRepository
    {
        void Save(Oferta ofertas);
        List<Oferta> Get();
        Oferta GetOferta(int orderId, int idSubida);
        List<Oferta> GetOfertaByIdSubida(int idSubida);
    }
}
