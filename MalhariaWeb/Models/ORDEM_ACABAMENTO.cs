using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ORDEM_ACABAMENTO
    {
        [Key]
        [DisplayName("#Ordem")]
        public int ID_ORDEM_ACABAMENTO { get; set; }
        [DisplayName("Produto")]
        public int ID_PRODUTO { get; set; }
        [DisplayName("Observação")]
        public string OBSERVACAO { get; set; }
        [DisplayName("Cor")]
        public int ID_COR { get; set; }
        [DisplayName("Metros Originais")]
     //   [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double METROS_ORIGINAIS { get; set; }
        [DisplayName("Kilos Originais")]
  //      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double KILOS_ORIGINAIS { get; set; }
        [DisplayName("Metros Acabados")]
  //      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double METROS_ACABADOS { get; set; }
        [DisplayName("Kilos Acabados")]
 //       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double KILOS_ACABADOS { get; set; }
        [DisplayName("Situação")]
        public eTipoSituacao SITUACAO { get; set; }
        [DisplayName("Metros Programados")]
 //       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double METROS_PROGRAMADOS { get; set; }
        [DisplayName("Kilos Programados")]
 //       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double KILOS_PROGRAMADOS { get; set; }

        public List<ORDEM_ACABAMENTO_PECAS> ORDEM_ACABAMENTO_PECAS { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
        public virtual COR COR { get; set; }


    }

    public enum eTipoSituacao
    {
        Programado = 0,
        Cancelado = 1,
        Emitido = 2,
        Recebido = 3,
        Encerrado = 4
    }

}