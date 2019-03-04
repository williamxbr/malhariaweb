using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ORDEM_ACABAMENTO_PEDIDO
    {
        [DisplayName("Ordem Acabamento")]
        public int ID_ORDEM_ACABAMENTO { get; set; }
        [DisplayName("Pedido")]
        public int ID_PEDIDO { get; set; }
    }
}