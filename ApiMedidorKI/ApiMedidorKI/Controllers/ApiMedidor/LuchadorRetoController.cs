using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiMedidorKI.Models;
 
using System.Web.Http.Cors;
 


namespace ApiMedidorKI.Controllers.ApiMedidor
{
    public class LuchadorRetoController : ApiController
    {
        private dbMedidorEntities db = new dbMedidorEntities();

        public LuchadorRetoController()
        {

            db = new dbMedidorEntities();
        }


        [HttpPost]
        [Route("Api/LuchadorReto/Crear")]
        public IHttpActionResult Post(MTLuchadorReto entidad)
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

                 MTLuchadorReto item =
                    db.MTLuchadorReto.
                    Where(w => w.CodigoLuchador == entidad.CodigoLuchador && w.CodigoReto == entidad.CodigoReto
                    && w.Activo == true && w.Eliminado == false).
                    FirstOrDefault();

                if (item != null)
                {
                    item.Activo = false;
                    item.UsuarioModifico = entidad.UsuarioInserto;
                    item.FechaModifico = DateTime.Now;
                    db.SaveChanges();
                }


                entidad.FechaInserto = DateTime.Now;
                entidad.Activo = true;
                entidad.Eliminado = false;

                db.MTLuchadorReto.Add(entidad);
                db.SaveChanges();

         

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
