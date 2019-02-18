using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ingresso.Data.Mapeamento
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            ToTable("Evento");
            HasKey(x => x.Id);
            Property(x => x.Titulo);
            Property(x => x.Imagem);
            Property(x => x.Preco);
            Property(x => x.Local);
            




        }
    }
}