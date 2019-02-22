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

        public Cartao(int id, string numero, string nome, string cvv, int usuarioId, Usuario usuario)
        {
            Id = id;
            Numero = numero;
            Nome = nome;
            Cvv = cvv;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }

        private string EncryptCvv(string cvv)
        {
            if (string.IsNullOrEmpty(cvv)) return "";
            var CVV = (cvv += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(CVV));
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