using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ingresso.Dominio
{
    public class Cartao
    {
        public Cartao()
        {

        }

        public Cartao(int id, string numero, string nome, string cvv)
        {
            Id = id;
            Numero = numero;
            Nome = nome;
            //   DataVencimento = dataVencimento;
            Cvv = EncryptPassword(cvv);


        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }


        public int Id { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }
        // public DateTime DataVencimento { get; set; }
        public string Cvv { get; set; }
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; }
    }
}