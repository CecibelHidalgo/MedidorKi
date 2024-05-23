using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiMedidorKI.Models;
 
 
 


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


        [HttpPost]
        [Route("Api/LuchadorReto/Eliminar")]
        public HttpResponseMessage Eliminar(MTLuchadorReto pEntidad)
        {
            try
            {
                MTLuchadorReto entidad = db.MTLuchadorReto
                    .Where(x => x.CodigoLuchadorReto == pEntidad.CodigoLuchadorReto && x.Eliminado == false)
                    .FirstOrDefault();

                if (entidad != null)
                {
                
                    entidad.UsuarioModifico = pEntidad.UsuarioInserto;
                    entidad.Eliminado = true;
                    entidad.FechaModifico = DateTime.Now;
                    entidad.Activo = false;
                    db.SaveChanges();
                    
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

               
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Api/LuchadorReto/Editar")]
        public HttpResponseMessage Editar(MTLuchadorReto pEntidad)
        {
            try
            {
                MTLuchadorReto entidad = db.MTLuchadorReto
                    .Where(x => x.CodigoLuchadorReto == pEntidad.CodigoLuchadorReto && x.Eliminado == false)
                    .FirstOrDefault();

                if (entidad != null)
                {


                    MTLuchadorReto itemExistenteAnterior =
                             db.MTLuchadorReto.
                             Where(w => w.CodigoLuchador == entidad.CodigoLuchador
                             && w.CodigoReto == entidad.CodigoReto

                             && w.Activo == false
                             && w.Eliminado == false).FirstOrDefault();


                    if (itemExistenteAnterior != null)
                    {
                        
                        itemExistenteAnterior.FechaModifico = DateTime.Now;
                        itemExistenteAnterior.UsuarioModifico = pEntidad.UsuarioInserto;

                        db.SaveChanges();
                    }

                    entidad.Punteo = pEntidad.Punteo;
                    entidad.EsEsfera = pEntidad.EsEsfera;

                    entidad.Activo = true;
                    entidad.Eliminado = false;
                    entidad.UsuarioModifico = pEntidad.UsuarioInserto;
                    entidad.FechaModifico = DateTime.Now;
                    db.SaveChanges();
                  
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
 
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
