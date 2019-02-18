using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.Dominio
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(int id, string nome, string cpf, string sexo, string endereco, int loginId, Login login, ICollection<Cartao> cartoes)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Endereco = endereco;
            LoginId = loginId;
            Login = login;
            Cartoes = cartoes;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
   //     public DateTime? DataNascimento { get; set; }
        public string Cpf { get;  set; }
        public string Sexo { get;  set; }
        public string Endereco { get;  set; }
        public int LoginId { get; set; }
        public virtual Login Login { get;  set; }
        public virtual ICollection<Cartao> Cartoes { get; set; }
    }
}