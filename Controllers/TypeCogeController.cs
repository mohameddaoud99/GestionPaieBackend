using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaieBack.Models;
using System.Web.Http.Description;
using System.Web.Http.Cors;
namespace PaieBack.Controllers
{
    [RoutePrefix("api/TypeCoge")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TypeCogeController : ApiController
    {

        // POST: api/TypeConge
        [ResponseType(typeof(void))]
        public HttpResponseMessage PostTypeconge(conge c)
        {
            if (ModelState.IsValid)
            {

                var conge = new conge();

                conge.code = c.code;
                conge.payer = c.payer;
                conge.libelle = c.libelle;
                conge.type = c.type;
                conge.edition = c.edition;
                conge.AutreType = c.AutreType;

                /*  grpaie.conge.Add(conge);
                  grpaie.SaveChanges();*/
                ChoixBD.MyDbContext.Set<conge>().Add(conge);
                ChoixBD.MyDbContext.SaveChanges();


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, conge);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = conge.code }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpGet, ActionName("GetTypeCoge")]
        [Route("GetTypeCoge")]
        public object GetTypeCoge()
        {
          //  return grpaie.conge.ToList();
            return ChoixBD.MyDbContext.Set<conge>().ToList();
        }

    }
}