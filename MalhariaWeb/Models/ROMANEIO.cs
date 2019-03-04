using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ROMANEIO
    {
        [Key]
        [DisplayName("Romaneio")]
        public int ID_ROMANEIO { get; set; }
        [DisplayName("Pedido")]
        public int ID_PEDIDO { get; set; }
        [DisplayName("Cliente")]
        public int ID_PESSOA { get; set; }
        [DisplayName("Situação")]
        public int SITUACAO { get; set; }
        [DisplayName("Tipo Romaneio")]
        public int TIPO_ROMANEIO { get; set; }
        [DisplayName("Quantidade")]
        public double QUANTIDADE_TOTAL { get; set; }

        public virtual List<ITENS_ROMANEIO> ITENS_ROMANEIO { get; set; }
        public virtual PEDIDO PEDIDO { get; set; }
        public virtual PESSOA PESSOA { get; set; }
    }
}