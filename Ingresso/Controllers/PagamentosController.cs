using Ingresso.Data;
using Ingresso.ViewModel.PagamentoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ingresso.Controllers
{
    public class PagamentosController : ApiController
    {

        private IngressoDbContexto db = new IngressoDbContexto();

        [Route("v1/pagamentos")]
        [HttpGet]
        public IEnumerable<ListaPagamentoViewModel> Get()
        {
            return db.Pagamentos
               .Select(x => new ListaPagamentoViewModel
               {

                   Numero = x.Numero,
                   NomeEvento = x.Evento.Titulo,
                   NomeUsuario = x.Usuario.Nome
                   

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