using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MalhariaWeb.Models
{
    public class MAQUINAS
    {
        [Key]
        [DisplayName("Id")]
        public int ID_MAQUINA { get; set; }
        [DisplayName("Maquina")]
        public string NOME_MAQUINA { get; set; }
    }
}
