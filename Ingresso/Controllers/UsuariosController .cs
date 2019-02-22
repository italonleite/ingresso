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
        public bool VerificarCpf(string cpf)
        {
            //any retorna um boolean
            return db.Usuarios.Any(x => x.Cpf == cpf);
        }

       [Route("v1/usuarios")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditarUsuarioViewModel model)
        {

            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o usuario",
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

        [Route("v1/usuarios/{id}")]
        [HttpGet]
        public Usuario Get(int id)
        {
            return db.Usuarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }



    }
}