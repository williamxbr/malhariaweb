using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class DEPOSITO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_DEPOSITO { get; set; }
        [DisplayName("Deposito")]
        public string NOME_DEPOSITO { get; set; }
        [DisplayName("Tipo")]
        public eTipoDeposito TIPO_DEPOSITO { get; set; }
    }

    public enum eTipoDeposito
    {
        Simples = 0,
        Cru = 1,
        Acabado = 2,
        Fios = 3,
        Insumos = 4
    }
}