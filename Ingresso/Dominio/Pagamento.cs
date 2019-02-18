using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.Dominio
{
    public class Pagamento
    {
        public Pagamento()
        {
        }

        public Pagamento(Usuario usuario, string numero, Evento evento)
        {
            Usuario = usuario;
          //  DataCriacao = dataCriacao;
            Numero = numero;
            Evento = evento;
        }
        public int Id { get;  set; }
        public int UsuarioId { get;  set; }
        public virtual Usuario Usuario { get;  set; }
       // public DateTime DataCriacao { get; private set; }
        public string Numero { get;  set; }
        public int EventoId { get;  set; }
        public virtual Evento Evento { get; set; }





    }
}