using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ingresso.ViewModel.PagamentoViewModel
{
    public class EditarPagamentoViewModel : Notifiable
    {
        public string Numero { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }


    }
}
