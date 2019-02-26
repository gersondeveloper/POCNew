using System;

namespace POCOi.Domain.OfertasContext.Entities
{
    public class Oferta
    {
        public int ID_OFERTA_PORTIFOLIO { get; set; }
        public int ID_SUBIDA { get; set; }
        public string NO_PLANO_FIXO { get; set; }
        public string NO_PACOTE_VC { get; set; }
        public string NO_PACOTE_LD { get; set; }
        public byte IND_SVA { get; set; }
        public decimal VAL_PRECO_TARGET { get; set; }
        public string NO_PACOTE_BANDA_LARGA { get; set; }
        public decimal VAL_PRECO_PLANO_FIXO { get; set; }
        public decimal VAL_PRECO_FIXO_LD { get; set; }
        public decimal VAL_PRECO_FIXO_VC { get; set; }
        public decimal VAL_PRECO_PLANO_VELOX_SEM_SVA { get; set; }
        public decimal VAL_PRECO_PLANO_VELOX_COM_SVA { get; set; }
        public decimal VAL_PRECO_SVA_VELOX { get; set; }
        public string NO_CAMPANHA { get; set; }
        public string NO_OFERTA { get; set; }
        public DateTime DT_CRIACAO { get; set; }
    }
}