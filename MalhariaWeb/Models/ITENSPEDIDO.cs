using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ITENSPEDIDO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_ITENSPEDIDO { get; set; }
        [DisplayName("Pedido")]
        public int ID_PEDIDO { get; set; }
        [DisplayName("Produto")]
        public int ID_PRODUTO { get; set; }
        [DisplayName("Quantidade")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double QUANTIDADE { get; set; }
        [DisplayName("Preço")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double PRECO { get; set; }
        [DisplayName("Unidade de Medida")]
        public int ID_UNIDADE_MEDIDA { get; set; }
        [DisplayName("Cor")]
        public int ID_COR { get; set; }
        [DisplayName("Desconto")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double DESCONTO { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
        public virtual COR COR { get; set; }
        public virtual UNIDADE_MEDIDA UNIDADE_MEDIDA { get; set; }
    }
}