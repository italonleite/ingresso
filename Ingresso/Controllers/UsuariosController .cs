using Ingresso.Data;
using Ingresso.Dominio;
using Ingresso.ViewModel.EventoViewModel;
using Ingresso.ViewModel.UsuarioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ingresso.Controllers
{
    public class UsuariosController : ApiController
    {
        private IngressoDbContexto db = new IngressoDbContexto();



        //[Route("v1/usuarios")]
        //[HttpGet]
        //public IEnumerable<ListaEventoViewModel> Get()
        //{
        //    return db.Usuarios
        //       .Select(x => new ListaUsuarioViewModel
        //        {
        //            Nome = x.Nome,
        //            DataNascimento = x.GetType(,
        //            Cpf = x.Cpf,
        //            Endereco = x.Endereco,
        //            Login = x.Login,
        //            Cartao = x.Cartao
                    
        //       })
        //       .ToList();
        //}


        //[Route("v1/eventos/{id}")]
        //[HttpGet]
        //public Evento Get(int id)
        //{
        //    return db.Eventos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        //}



    }
}