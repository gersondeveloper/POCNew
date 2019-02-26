using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using POCOi.Domain.OfertasContext.Repositories;
using POCOi.Infra.OfertasContext.DataContexts;
using POCOi.Shared;
using POCOi.Domain.OfertasContext.Entities;

namespace POCOi.Infra.OrdersContext.Repositories
{
    public class OfertasRepository : IOfertasRepository
    {
        private readonly OfertasDataContext _context;

        public OfertasRepository(OfertasDataContext context)
        {
            _context =  context;
        }

        public List<Oferta> Get()
        {
            List<Oferta> ofertas = new List<Oferta>();

             string conString = "User Id=isuser;Password=N0v0Fr0nt3nd_;" +
                "Data Source=10.58.1.195:1549/nfedx01;";

                using (OracleConnection con = new OracleConnection(conString))
                {
                    Oferta newOferta;

                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        try
                        {
                            con.Open();
                            cmd.BindByName = true;                            

                            cmd.CommandText = "select * from gz_tb_portifolio_ofertas where id_subida = 21";

                            OracleParameter id = new OracleParameter("idSubida", 21);
                            cmd.Parameters.Add(id);

                            //Execute the command and use DataReader to display the data
                            OracleDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                    newOferta = new Oferta();
                                    newOferta.ID_OFERTA_PORTIFOLIO = Convert.ToInt16(dr["ID_OFERTA_PORTIFOLIO"]);
                                    newOferta.ID_SUBIDA = Convert.ToInt16(dr["ID_SUBIDA"]);
                                    newOferta.NO_PLANO_FIXO = Convert.ToString(dr["NO_PLANO_FIXO"]);
                                    newOferta.NO_PACOTE_VC = Convert.ToString(dr["NO_PACOTE_VC"]);
                                    newOferta.NO_PACOTE_LD = Convert.ToString(dr["NO_PACOTE_LD"]);
                                    newOferta.IND_SVA = Convert.ToByte(dr["IND_SVA"]);
                                    newOferta.VAL_PRECO_TARGET = Convert.ToDecimal(dr["VAL_PRECO_TARGET"]);
                                    newOferta.NO_PACOTE_BANDA_LARGA = Convert.ToString(dr["NO_PACOTE_BANDA_LARGA"]);
                                    newOferta.VAL_PRECO_PLANO_FIXO = Convert.ToDecimal(dr["VAL_PRECO_PLANO_FIXO"]);
                                    newOferta.VAL_PRECO_FIXO_LD = Convert.ToDecimal(dr["VAL_PRECO_FIXO_LD"]);
                                    newOferta.VAL_PRECO_FIXO_VC = Convert.ToDecimal(dr["VAL_PRECO_FIXO_VC"]);
                                    newOferta.VAL_PRECO_PLANO_VELOX_SEM_SVA = Convert.ToDecimal(dr["VAL_PRECO_PLANO_VELOX_SEM_SVA"]);
                                    newOferta.VAL_PRECO_PLANO_VELOX_COM_SVA = Convert.ToDecimal(dr["VAL_PRECO_PLANO_VELOX_COM_SVA"]);
                                    newOferta.VAL_PRECO_SVA_VELOX = Convert.ToDecimal(dr["VAL_PRECO_SVA_VELOX"]);
                                    newOferta.NO_CAMPANHA = Convert.ToString(dr["NO_CAMPANHA"]);
                                    newOferta.NO_OFERTA = Convert.ToString(dr["NO_OFERTA"]);
                                    newOferta.DT_CRIACAO = Convert.ToDateTime(dr["DT_CRIACAO"]);

                                    ofertas.Add(newOferta);
                            }

                            dr.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    return ofertas;
                }
            }  
        }

        public Oferta GetOferta(int orderId, int idSubida)
        {
            throw new NotImplementedException();
        }

        public List<Oferta> GetOfertaByIdSubida(int idSubida)
        {
            throw new NotImplementedException();
        }

        public void Save(Oferta ofertas)
        {
            throw new NotImplementedException();
        }
    }
}