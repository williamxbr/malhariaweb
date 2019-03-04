using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ORDEM_ACABAMENTO_PECAS
    {
        [Key]
        public int ID_ORDEM_ACABAMENTO_PECAS { get; set; }
        [DisplayName("Ordem Acabamento")]
        public int ID_ORDEM_ACABAMENTO { get; set; }
        [DisplayName("Peça")]
        public int ID_PECA { get; set; }
        [DisplayName("Peso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double PESO { get; set; }
        [DisplayName("Metros")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double METROS { get; set; }

        public virtual PECAS PECAS { get; set; }
    }
}