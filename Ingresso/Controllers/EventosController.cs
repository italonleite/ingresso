using Ingresso.Data;
using Ingresso.Dominio;
using Ingresso.ViewModel.EventoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ingresso.Controllers
{
    [EnableCors(origins: "http://localhost:54616/v1", headers: "*", methods: "*")]
    public class EventosController : ApiController
    {
        private IngressoDbContexto db = new IngressoDbContexto();
               
        [Route("v1/eventos")]
        [HttpGet]
        public IEnumerable<ListaEventoViewModel> Get()
        {
            return db.Eventos
               .Select(x => new ListaEventoViewModel
                {
                    Titulo = x.Titulo,
                    Imagem = x.Imagem,
                    Preco = x.Preco,
                    Local = x.Local
                })
               .ToList();
        }


        //[Route("v1/eventos")]
        //[HttpGet]
        //public IEnumerable<ListaEventoViewModel> Get()
        //{
        //    return db.Eventos
        //       .Select(x => new ListaEventoViewModel
        //       {
        //           Titulo = x.Titulo,
        //           Imagem = x.Imagem,
        //           Preco = x.Preco,
        //           Local = x.Local
        //       })
        //       .ToList();
        //}

        [Route("v1/eventos/{id}")]
        [HttpGet]
        public Evento Get(int id)
        {
            return db.Eventos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }



    }
}