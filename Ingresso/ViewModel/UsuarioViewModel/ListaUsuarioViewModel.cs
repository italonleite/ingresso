using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.ViewModel.UsuarioViewModel
{
    public class ListaUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public Login Login { get; set; }
        public Cartao Cartao { get; set; }
    }
}