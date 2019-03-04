using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ORDEM_MALHARIA_PEDIDO
    {
        [DisplayName("Ordem Malharia")]
        public int ID_ORDEM_MALHARIA { get; set; }
        [DisplayName("Pedido")]
        public int ID_PEDIDO { get; set; }
    }
}