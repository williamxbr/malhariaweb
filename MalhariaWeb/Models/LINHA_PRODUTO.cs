using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class LINHA_PRODUTO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_LINHA_PRODUTO { get; set; }
        [DisplayName("Linha de Produto")]
        public string NOME_LINHA_PRODUTO { get; set; }
    }
}