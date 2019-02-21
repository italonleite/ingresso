using Ingresso.Data;
using Ingresso.Dominio;
using Ingresso.ViewModel;
using Ingresso.ViewModel.UsuarioViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ingresso.Controllers
{
    [EnableCors(origins: "https://ingressoapi.azurewebsites.net/v1", headers: "*", methods: "*")]

    public class UsuariosController : ApiController
    {
        private IngressoDbContexto db = new IngressoDbContexto();



        [Route("v1/usuarios")]
        [HttpGet]
        public IEnumerable<ListaUsuarioViewModel> Get()
        {
            return db.Usuarios
               .Select(x => new ListaUsuarioViewModel
               {
                   Id = x.Id,
                   Nome = x.Nome,
                   Cpf = x.Cpf,
                   Sexo = x.Sexo,
                   Endereco = x.Endereco,
                   Login = x.Login,
                   Senha = x.Senha,
                   Cartoes = x.Cartoes

               })
               .ToList();
        }
        [Route("v1/usuarios/{login}")]
        [HttpGet]
        public bool VerificarSeUsuarioExiste(string login)
        {
            //any retorna um boolean
            return db.Usuarios.Any(x => x.Login == login);
        }


        [Route("v1/usuarios")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorUsuarioViewModel model)
        {

            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };

            var usuario = new Usuario();
            usuario.Nome = model.Nome;
            usuario.Cpf = model.Cpf;
            usuario.Sexo = model.Sexo;
            usuario.Endereco = model.Endereco;
            usuario.Login = model.Login;
            usuario.Senha = model.Senha;
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuario cadastrado com sucesso!",
                Data = usuario
            };
        }


        [Route("v1/usuarios")]
        [HttpPost]
        public ResultViewModel Post([FromBody]UsuarioExisteViewModel model)
        {

            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Usuario não encontrado",
                    Data = model.Notifications
                };

            var usuario = new Usuario();            
            usuario.Login = model.Login;
            
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuario cadastrado com sucesso!",
                Data = usuario
            };
        }
        //[Route("v1/eventos/{id}")]
        //[HttpGet]
        //public Evento Get(int id)
        //{
        //    return db.Eventos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        //}



    }
}