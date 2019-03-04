using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MalhariaWeb.Models
{
    public class UNIDADE_MEDIDA
    {
        [Key]
        [DisplayName("Id")]
        public int ID_UNIDADE_MEDIDA { get; set; }
        [DisplayName("Unidade Medida")]
        public string NOME_UNIDADE_MEDIDA { get; set; }
    }
}
