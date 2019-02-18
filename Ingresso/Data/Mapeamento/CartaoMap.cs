using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ingresso.Data.Mapeamento
{
    public class CartaoMap : EntityTypeConfiguration<Cartao>
    {
        public CartaoMap()
        {
            ToTable("Cartao");
           HasKey(x => x.Id);
            Property(x => x.Numero);
            Property(x => x.Nome);
              
             
          

        }
    }
}