using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MalhariaWeb.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=MalhariaWebEntities")
        {
           // Database.SetInitializer<ContextDB>(null); 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ACONDICIONAMENTO> ACONDICIONAMENTO { get; set; }
        public DbSet<COR> COR { get; set; }
        public DbSet<DEPOSITO> DEPOSITO { get; set; }
        public DbSet<ITENS_ROMANEIO> ITENS_ROMANEIO { get; set; }
        public DbSet<ITENSPEDIDO> ITENSPEDIDO { get; set; }
        public DbSet<LINHA_PRODUTO> LINHA_PRODUTO { get; set; }
        public DbSet<MAQUINAS> MAQUINAS { get; set; }
        public DbSet<OPERADOR> OPERADOR { get; set; }
        public DbSet<ORDEM_ACABAMENTO> ORDEM_ACABAMENTO { get; set; }
        public DbSet<ORDEM_ACABAMENTO_PECAS> ORDEM_ACABAMENTO_PECAS { get; set; }
        public DbSet<ORDEM_MALHARIA> ORDEM_MALHARIA { get; set; }
        public DbSet<PARAMETRO> PARAMETRO { get; set; }
        public DbSet<PECAS> PECAS { get; set; }
        public DbSet<PEDIDO> PEDIDO { get; set; }
        public DbSet<PESSOA> PESSOA { get; set; }
        public DbSet<PRODUTO> PRODUTO { get; set; }
        public DbSet<ROMANEIO> ROMANEIO { get; set; }
        public DbSet<UNIDADE_MEDIDA> UNIDADE_MEDIDA { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
     }
}