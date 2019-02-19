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
                   NomeUsuario = x.Usuario.Nome,
                  
               })
               .ToList();
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}