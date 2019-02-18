using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ingresso.Data.Mapeamento
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoMap()
        {
            ToTable("Pagamento");
            HasKey(x => x.Id);       
            Property(x => x.Numero).IsRequired();
            HasRequired(x => x.Usuario);
            HasRequired(x => x.Evento);
        }
        
    }
}