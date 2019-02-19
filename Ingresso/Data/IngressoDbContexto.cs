﻿using Ingresso.Data.Mapeamento;
using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ingresso.Data
{
    public class IngressoDbContexto : DbContext
    {
        public IngressoDbContexto() : base(@"Server=DESKTOP-08PGJ59\SQLNOVO;Database=ingressoNovo;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new CartaoMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PagamentoMap());

                  }

    }
}