using System;
using System.Web.Http;
using System.Threading.Tasks;
//using ApiMedidorKI.Models.LoginApi;
using System.Linq;
using ApiMedidorKI.Models;
using ApiMedidorKI.Controllers;


namespace ApiMedidorKI.Controllers
{
    public class InicioSesionController : ApiController
    {
        [HttpPost]
        [Route("Api/Login")]
        public async Task<IHttpActionResult> Autenticacion(Credenciales credenciales)
        {
            try
            {
                GeneraToken GeneraToken = new GeneraToken();
                Token TokenGenerado = new Token();

                if (ModelState.IsValid)//usuarioToken y passwordToken, usuario y contrasenia son requeridos en la clase Credenciales
                {
                    dbMedidorEntities db = new dbMedidorEntities();

                    // Validar usuario en la base de datos
                    var usuario = db.MTUsuario.Where(x => !x.Eliminado && x.Usuario == credenciales.Usuario && x.Clave == credenciales.Clave).FirstOrDefault();
                    if (usuario != null)
                    {
                        TokenGenerado = await GeneraToken.Generar(credenciales.UsuarioToken, credenciales.ClaveToken);
                        if (TokenGenerado.Estado)
                        {
                            return Ok(TokenGenerado);
                        }
                        else
                        {
                            return BadRequest(TokenGenerado.Error_Description); ;
                        }
                    }
                    else
                    {
                        return BadRequest("Usuario o clave incorrecto");
                    }
                }
                else
                {
                    return BadRequest("Datos incompletos.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
