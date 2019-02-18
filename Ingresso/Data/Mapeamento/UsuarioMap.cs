using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ingresso.Data.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired();
           // Property(x => x.DataNascimento);
            Property(x => x.Cpf).IsRequired();
            Property(x => x.Sexo).IsRequired();
            Property(x => x.Endereco).IsRequired();
            HasRequired(l => l.Login);
            HasMany(c => c.Cartoes);


        }
    }
}