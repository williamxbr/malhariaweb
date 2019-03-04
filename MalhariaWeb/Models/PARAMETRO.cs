using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class PARAMETRO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_PARAMETRO { get; set; }
        [DisplayName("Deposito Cru")]
        public int ID_DEPOSITO_CRU { get; set; }
        [DisplayName("Deposito Acabado")]
        public int ID_DEPOSITO_ACABADO { get; set; }
        [DisplayName("Cliente Proprietario")]
        public int CLIENTE_PROPRIETARIO { get; set; }

    }
}