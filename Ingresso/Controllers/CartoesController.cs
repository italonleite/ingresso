using Ingresso.Data;
using Ingresso.ViewModel.CartaoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ingresso.Controllers
{
   

    public class CartoesController : ApiController
    {
        private IngressoDbContexto db = new IngressoDbContexto();

        [Route("v1/cartoes")]
        [HttpGet]
        public IEnumerable<ListaCartaoViewModel> Get()
        {
            return db.Cartoes
               .Select(x => new ListaCartaoViewModel
               {
                   Numero = x.Numero,
                 
                  
               })
               .ToList();
        }
      
    }
}