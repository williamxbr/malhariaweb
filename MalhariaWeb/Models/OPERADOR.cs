using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MalhariaWeb.Models
{
    public class OPERADOR
    {
        [Key]
        [DisplayName("Id")]
        public int ID_OPERADOR { get; set; }
        [DisplayName("Operador")]
        public string NOME_OPERADOR { get; set; }
    }
}
