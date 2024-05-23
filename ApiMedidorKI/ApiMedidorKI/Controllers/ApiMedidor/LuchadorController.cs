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
  
    [Authorize]
    public class LuchadorController : ApiController
    {

        private dbMedidorEntities db = new dbMedidorEntities();

        public LuchadorController()
        {
           
            db = new dbMedidorEntities();
        }

        /// <summary>
        /// lista luchadores activos
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public HttpResponseMessage Listar()
        {

            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;

              
                var Luchadores = (from b in db.MTLuchador
                                  where b.Eliminado == false && b.Activo == true
                                  select new
                                  {
                                      b.CodigoLuchador,
                                      b.NombreLuchador,
                                      b.Activo,
                                      b.Eliminado
                                  }).ToList();

                if (Luchadores != null && Luchadores.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Luchadores);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }

        }

    }
}
