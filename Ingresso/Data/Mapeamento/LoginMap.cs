using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ingresso.Data.Mapeamento
{
    public class LoginMap : EntityTypeConfiguration<Login>
    {
        public LoginMap()
        {
            ToTable("Login");
            HasKey(x => x.Id);
            Property(x => x.User).IsRequired();
            Property(x => x.Senha).IsRequired();

        }
    }
}