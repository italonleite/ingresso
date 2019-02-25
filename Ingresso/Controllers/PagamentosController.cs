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
                   NumeroTicket = x.Numero,
                   NomeUsuario = x.Usuario.Nome,
                   Cpf = x.Usuario.Cpf,
                   NomeEvento = x.Evento.Titulo,
                   LocalEvento = x.Evento.Local,
                   

               })
               .ToList();
        }
    }
}
