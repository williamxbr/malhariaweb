using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MalhariaWeb.Models
{
    public class PECAS
    {
        [Key]
        [DisplayName("Id")]
        public int ID_PECA { get; set; }
        [DisplayName("Produto")]
        public int ID_PRODUTO { get; set; }
        [DisplayName("Unidade Medida")]
        public int ID_UNIDADE_MEDIDA { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DisplayName("Metros")]
        public Nullable<double> METROS { get; set; }
        [DisplayName("Deposito")]
        public int ID_DEPOSITO { get; set; }
        [DisplayName("Ordem Acabamento")]
        public Nullable<int> ID_ORDEM_ACABAMENTO { get; set; }
        [DisplayName("Operador")]
        public Nullable<int> ID_OPERADOR { get; set; }
        [DisplayName("Data Entrada")]
        public Nullable<System.DateTime> DATA_ENTRADA { get; set; }
        [DisplayName("Hora Entrada")]
        public Nullable<System.DateTime> HORA_ENTRADA { get; set; }
        [DisplayName("Situação")]
        public eSituacaoPeca SITUACAO { get; set; }
        [DisplayName("Peso Liquido")]
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double PESO_LIQUIDO { get; set; }
        [DisplayName("Cor")]
        public Nullable<int> ID_COR { get; set; }
        [DisplayName("Qualidade")]
        public eQualidadePeca QUALIDADE { get; set; }
        [DisplayName("Acondicionamento")]
        public int ID_ACONDICIONAMENTO { get; set; }
        [DisplayName("Data Saida")]
        public Nullable<System.DateTime> DATA_SAIDA { get; set; }
        [DisplayName("Maquina")]
        public Nullable<int> ID_MAQUINA { get; set; }
        [DisplayName("Largura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double LARGURA { get; set; }
        [DisplayName("Peça Dividida")]
        public Nullable<bool> EH_PECA_DIVIDIDA { get; set; }
        [DisplayName("Gramatura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<double> GRAMATURA { get; set; }
        [DisplayName("Peso Bruto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public double PESO_BRUTO { get; set; }
        [DisplayName("Tipo Peça")]
        public eTipoPeca TIPO_PECA { get; set; }
        [DisplayName("Peça Origem")]
        public Nullable<int> PECA_ORIGEM { get; set; }

        public virtual PRODUTO PRODUTO { get; set; }
        public virtual UNIDADE_MEDIDA UNIDADE_MEDIDA { get; set; }
        public virtual DEPOSITO DEPOSITO { get; set; }
        public virtual OPERADOR OPERADOR { get; set; }
        public virtual COR COR { get; set; }
        public virtual ACONDICIONAMENTO ACONDICIONAMENTO { get; set; }
        public virtual MAQUINAS MAQUINAS { get; set; }

    }

    public enum eSituacaoPeca
    {
        Disponivel = 0,
        Baixado = 1,
        Producao = 2,
        PecaMae = 3,
        Revisado = 4,
        Pesagem = 5
    }

    public enum eTipoPeca
    {
        Fios = 0,
        Cru = 1,
        Acabado = 2
    }

    public enum eQualidadePeca
    {
        Primeira = 0,
        Segunda = 1,
        Terceira = 2
    }

}
