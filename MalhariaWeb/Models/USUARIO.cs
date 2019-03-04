using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MalhariaWeb.Utils;

namespace MalhariaWeb.Models
{
    public class USUARIO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_USUARIO { get; set; }
        [DisplayName("Nome")]
        [Required]
        public string NOME_USUARIO { get; set; }
        [DisplayName("Senha")]
        [Required]
        public string SENHA { get; set; }
        [DisplayName("Tipo")]
        [Required]
        public eTipoUsuario TIPO_USUARIO { get; set; }
        [DisplayName("Nome de Exibição")]
        [Required]
        public string NOME_COMPLETO_USUARIO { get; set; }


        public bool isValid(string _UserName, string _Password)
        {
            string _sql = @"Select NOME_USUARIO FROM USUARIO " +
                          @"Where NOME_USUARIO = @u AND SENHA = @s";


            var cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MalhariaWebEntities"].ConnectionString);
            var cmd = new SqlCommand(_sql, cn);
            cmd.Parameters
                .Add(new SqlParameter("@u", SqlDbType.VarChar))
                .Value = NOME_USUARIO;
            cmd.Parameters
                .Add(new SqlParameter("@s", SqlDbType.VarChar))
                .Value = SHA1.Encode(SENHA); // (laloca) = cf5e2f8199b7f0bac8f529af29d8999b7d1d2902
            cn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Dispose();
                cmd.Dispose();
                return true;
            }
            else
            {
                reader.Dispose();
                cmd.Dispose();
                return false;
            }
        }
        
    }

    public enum eTipoUsuario
    {
        Operador = 0,
        PCP = 1,
        Gerencia = 2,
        Administrador = 3,
        Vendas = 4
    }

}