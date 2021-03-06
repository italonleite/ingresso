﻿using Ingresso.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.ViewModel.UsuarioViewModel
{
    public class ListaUsuarioViewModel
    {
       
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public IEnumerable<Cartao> Cartoes { get; set; }
        

    }
}