using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiMedidorKI.Models;

namespace ApiMedidorKI.Controllers.ApiMedidor
{
    public class RetoController : ApiController
    {

        private dbMedidorEntities db = new dbMedidorEntities();

        public RetoController()
        {

            db = new dbMedidorEntities();
        }

        /// <summary>
        /// Lista reto por categoria
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public HttpResponseMessage ListarRetoPorCategoria()
        {

            try
            {

                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;


                var retoCategoria = (from reto in db.MTReto
                                     join categoria in db.MTCategoria
                                     on reto.CodigoCategoria equals categoria.CodigoCategoria
                                     where reto.Eliminado == false && reto.Activo == true

                                     select new
                                    {
                                      reto.CodigoCategoria,
                                      categoria.NombreCategoria,
                                      reto.CodigoReto,
                                      reto.NombreReto
                                      
                                    }).ToList();


                if (retoCategoria != null && retoCategoria.Count() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, retoCategoria);
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
