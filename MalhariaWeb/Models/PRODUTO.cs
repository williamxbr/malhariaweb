using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MalhariaWeb.Models
{
    public class PRODUTO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_PRODUTO { get; set; }
        [DisplayName("Nome")]
        public string NOME_PRODUTO { get; set; }
        [DisplayName("Unidade Medida")]
        public int ID_UNIDADE_MEDIDA { get; set; }
        [DisplayName("Código")]
        public string CODIGO_PRODUTO { get; set; }
        [DisplayName("Linha Produto")]
        public int ID_LINHA_PRODUTO { get; set; }
        [DisplayName("Tipo Produto")]
        public eTipoProduto TIPO_PRODUTO { get; set; }

        public virtual UNIDADE_MEDIDA UNIDADE_MEDIDA { get; set; }
        public virtual LINHA_PRODUTO LINHA_PRODUTO { get; set; }
    }

    public enum eTipoProduto
    {
        Fios = 0,
        Malha = 1,
        Tecido = 2
    }
}
