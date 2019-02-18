using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.Dominio
{
    public class Evento
    {


        public Evento()
        {

        }

        public Evento(string titulo, string imagem, decimal preco, string local)
        {
            Titulo = titulo;
            Imagem = imagem;
            Preco = preco;
            Local = local;

        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public string Local { get; set; }


    }
}