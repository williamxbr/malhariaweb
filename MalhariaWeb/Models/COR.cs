using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class COR
    {
        [Key]
        [DisplayName("Id")]
        public int ID_COR { get; set; }
        [DisplayName("Cor")]
        public string NOME_COR { get; set; }
    }
}