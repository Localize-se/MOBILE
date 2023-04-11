using AppLocalize_se.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocalize_se.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;

        private const string apiUrlBase = "";//Http do Somee 
        //xyz ---> Site da sua Api

        public UsuarioService()
        {
            _request = new Request();
        }
        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            //Regitrar: Rota para o método na Api que registrar o usuário
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            //Autenticar: Rota para o método na Api que Autentica com login e senha 
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }
    }
}

