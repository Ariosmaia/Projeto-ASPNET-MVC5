using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using System.Data.SqlClient;




namespace CaelumEstoque.DAO
{
    public class EstoqueContext : DbContext
    {

        
        public DbSet<Produto> Produtos{ get; set; }

        public DbSet<CategoriaDoProduto> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=ALLANRIOS\SQLEXPRESS;Database=CaelumEstoque.DAO.EstoqueContext;Trusted_Connection=true;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ALLAN_DIRETRIZ\SQLEXPRESS;Database=CaelumEstoque.DAO.EstoqueContext;Trusted_Connection=true;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<CategoriaDoProduto>()
        //        .HasKey("ProdutoId");
        //}

        //protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
        //{
        //    optionsbuilder.usesqlserver(@"server=(localdb)\mssqllocaldb;database=estoquedb;trusted_connection=true;");
        //}
    }
}