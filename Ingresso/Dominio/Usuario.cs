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

        public Usuario(int id, string nome, string cpf, string sexo, string endereco, string login, string senha, ICollection<Cartao> cartoes)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Endereco = endereco;
            Login = login;
            Senha = senha;
            Cartoes = cartoes;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
   //     public DateTime? DataNascimento { get; set; }
        public string Cpf { get;  set; }
        public string Sexo { get;  set; }
        public string Endereco { get;  set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Cartao> Cartoes { get; set; }

             


    }
}