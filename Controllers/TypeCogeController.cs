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

                // conge.code = c.code;
                int matr = ChoixBD.MyDbContext.Set<conge>().Select(codeType => new { code = codeType.code, }).ToList().Count() + 1;

                conge.code = "0" + matr.ToString();

                //conge.payer = null;
                conge.libelle = c.libelle;
                conge.type = c.type;
                //conge.edition = null;
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

        [HttpDelete, ActionName("DeleteTypeCoge")]
        [Route("DeleteTypeCoge")]
        public IHttpActionResult DeleteTypeCoge(string code)
        {
            conge aut = ChoixBD.MyDbContext.Set<conge>()
                .Where(x => x.code.Equals(code))
                .First();
            if (aut == null)
            {
                return NotFound();
            }

            ChoixBD.MyDbContext.Set<conge>().Remove(aut);
            ChoixBD.MyDbContext.SaveChanges();
            return Ok(aut);
        }




        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeCoge(string code, conge c)
        {

            var conge = ChoixBD.MyDbContext.Set<conge>().Where(cc => cc.code == code).First();

            //conge.payer = c.payer;
            conge.libelle = c.libelle;
            conge.type = c.type;
            //conge.edition = c.edition;
            conge.AutreType = c.AutreType;

            ChoixBD.MyDbContext.SaveChanges();

            return Ok(c);
        }




            [HttpGet, ActionName("NbCongeParMoisAccepte")]
            [Route("NbCongeParMoisAccepte")]
            public object NbCongeParMoisAccepte()
            {
                DateTime currentDate = DateTime.Now;
                return ChoixBD.MyDbContext.Set<majconge>()



                    .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "A")

                    .Select(majconge => majconge.code)
                    .Count();
            }
        



        }
}