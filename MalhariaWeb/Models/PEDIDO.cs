using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class PEDIDO
    {   
        [Key]
        [DisplayName("Pedido")]
        public int ID_PEDIDO { get; set; }
        [DisplayName("Pessoa")]
        public int ID_PESSOA { get; set; }
        [DisplayName("Data do pedido")]
        public DateTime DATA_PEDIDO { get; set; }
        [DisplayName("Data da entrega")]
        public DateTime DATA_ENTREGA { get; set; }
        [DisplayName("Situação")]
        public eSituacaoPedido SITUACAO { get; set; }
        [DisplayName("Tipo pedido")]
        public eTipoPedido TIPO_PEDIDO { get; set; }
        
        public List<ITENSPEDIDO> ITENSPEDIDO { get; set; }

        public virtual PESSOA PESSOA { get; set; }

    }

    public enum eSituacaoPedido
    {
        Digitado = 0,
        Aprovado = 1,
        Cancelado = 2,
        Encerrado = 3
    }

    public enum eTipoPedido
    {
        Venda = 0,
        Faccao = 1
    }
}