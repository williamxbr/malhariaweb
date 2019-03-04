using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class PESSOA
    {
        [Key]
        [DisplayName("Id")]
        public int ID_PESSOA { get; set; }
        [DisplayName("Nome")]
        public string NOME_PESSOA { get; set; }
        [DisplayName("Tipo Pessoa")]
        public eTipoPessoa TIPO_PESSOA { get; set; }
        [DisplayName("Endereço")]
        public string LOGRADOURO { get; set; }
        [DisplayName("Bairro")]
        public string BAIRRO { get; set; }
        [DisplayName("Cidade")]
        public string CIDADE { get; set; }
        [DisplayName("Estado")]
        public string ESTADO { get; set; }
        [DisplayName("Pais")]
        public string PAIS { get; set; }
        [DisplayName("Cep")]
        public string CEP { get; set; }
        [DisplayName("Telefone")]
        public string TELEFONE { get; set; }
        [DisplayName("Fax")]
        public string FAX { get; set; }
        [DisplayName("Inscrição Federal")]
        public string INSCRICAO_FEDERAL { get; set; }
        [DisplayName("Inscrição Estadual")]
        public string INSCRICAO_ESTADUAL { get; set; }
        [DisplayName("Cliente")]
        public bool EHCLIENTE { get; set; }
        [DisplayName("Fornecedor")]
        public bool EHFORNECEDOR { get; set; }
        [DisplayName("Representante")]
        public bool EHREPRESENTANTE { get; set; }
        [DisplayName("Transportadora")]
        public bool EHTRANSPORTADORA { get; set; }
    }

    public enum eTipoPessoa
    {
        Fisica = 0,
        Juridica = 1,
        Outros = 3
    }
}