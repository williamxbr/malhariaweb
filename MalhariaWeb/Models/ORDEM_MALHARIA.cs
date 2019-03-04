using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ORDEM_MALHARIA
    {
        [Key]
        [DisplayName("Id")]
        public int ID_ORDEM_MALHARIA { get; set; }
        [DisplayName("Produto")]
        public int ID_PRODUTO { get; set; }
        [DisplayName("Quantidade")]
        public double QUANTIDADE { get; set; }
        [DisplayName("Situação")]
        public eSituacaoMalharia SITUACAO { get; set; }
        [DisplayName("Maquina")]
        public int ID_MAQUINA { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
        public virtual MAQUINAS MAQUINAS { get; set; }

    }

    public enum eSituacaoMalharia
    {
        Programado = 0,
        Cancelado = 1,
        Emitido = 2,
        Encerrado = 4
    }

}