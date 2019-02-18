using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.Dominio
{
    public class Login
    {
        public Login()
        {

        }
        public Login(string user, string senha)
        {
            User = user;
            Senha = senha;
        }

        public int Id { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
    }
}