using PaieBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace PaieBack.Controllers
{
    [RoutePrefix("api/Autorisation")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AutorisationController : ApiController
    {
        [HttpGet, ActionName("GetAutorisation")]
        [Route("GetAutorisation")]
        public object GetMajCoge()
        {
            return ChoixBD.MyDbContext.Set<majconge>().ToList();
        }

        [HttpGet, ActionName("GetAutorisationByUser")]
        [Route("GetAutorisationByUser")]
        public object GetMajCogeUtilisateur(string matricule, string nomprenom)
        {
            return ChoixBD.MyDbContext.Set<autorisation>()
                .Where(x => x.matricule.Equals(matricule) && x.nomprenom.Equals(nomprenom) && x.etat == "E")
                .ToList();
        }


        [HttpGet, ActionName("GetUtilisateur")]
        [Route("GetUtilisateur")]
        public object GetUtilisateur(string MATR)
        {
            return ChoixBD.MyDbContext.Set<personnel>()

                .Where(x => x.MATR.Equals(MATR))
                 .Select(personnel => new
                 {

                     NOMPRENOM1 = personnel.NOMPRENOM1
                 })
                .ToList();
        }

        [HttpGet, ActionName("GetAutorisationEnAttenteByIdE")]
        [Route("GetAutorisationEnAttenteByIdE")]
        public IEnumerable<autorisation> GetAutorisationEnAttenteByIdE(string matricule)
        {
            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.matricule == matricule && c.etat == "E").ToList();
        }

        [HttpGet, ActionName("GetAutorisationAccepterByIdE")]
        [Route("GetAutorisationAccepterByIdE")]
        public IEnumerable<autorisation> GetCongesAccepterByIdEmployee(string matricule)
        {
            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.matricule == matricule && c.etat == "A").ToList();
        }

        [HttpGet, ActionName("GetAutorisationRefuserByIdE")]
        [Route("GetAutorisationRefuserByIdE")]
        public IEnumerable<autorisation> GetAutorisationRefuserByIdE(string matricule)
        {
            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.matricule == matricule && c.etat == "R").ToList();
        }


        // POST: api/MajCoge
        [ResponseType(typeof(autorisation))]
        public HttpResponseMessage PostAutorisation(autorisation o)
        {


            if (ModelState.IsValid)
            {
                var auto = new autorisation();

                auto.date = o.date;
                auto.nbrheure = o.nbrheure;
                auto.matricule = o.matricule;
                auto.nomprenom = o.nomprenom;

                auto.solde = 0;
                auto.payer = "oui";

                auto.description = o.description;
                auto.etat = "E";


                ChoixBD.MyDbContext.Set<autorisation>().Add(auto);
                ChoixBD.MyDbContext.SaveChanges();


                // return Ok(new { status = 200, isSuccess = true, message = "Ajouter Existe", Details = p });
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, o);

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            /*  if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }
              ChoixBD.MyDbContext.Set<majconge>().Add(p);
              ChoixBD.MyDbContext.SaveChanges();

              return Ok(new { status = 200, isSuccess = true, message = "Ajouter Existe", Details = p });
            */

        }



        [HttpPost, ActionName("PostAutorisationADMIN")]
        [Route("PostAutorisationADMIN")]
        public HttpResponseMessage PostAutorisationADMIN(autorisation o)
        {


            if (ModelState.IsValid)
            {
                var auto = new autorisation();

                auto.date = o.date;
                auto.nbrheure = o.nbrheure;
                auto.matricule = o.matricule;
                auto.nomprenom = o.nomprenom;

                auto.solde = 0;
                auto.payer = "oui";

                auto.description = o.description;
                auto.etat = "A";


                ChoixBD.MyDbContext.Set<autorisation>().Add(auto);
                ChoixBD.MyDbContext.SaveChanges();



                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, o);

                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }


        }


        [HttpDelete, ActionName("DeleteMajCogeUtilisateur")]
        [Route("DeleteMajCogeUtilisateur")]
        public IHttpActionResult DeleteMajCogeUtilisateur(string matricule, string nomprenom, DateTime date)
        {
            autorisation aut = ChoixBD.MyDbContext.Set<autorisation>()
                .Where(x => x.matricule.Equals(matricule) && x.nomprenom.Equals(nomprenom) && x.date.Equals(date))
                .First();
            if (aut == null)
            {
                return NotFound();
            }

            ChoixBD.MyDbContext.Set<autorisation>().Remove(aut);
            ChoixBD.MyDbContext.SaveChanges();
            return Ok(aut);
        }


        // PUT: api/Personnel?MATR=000167
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajCoge(DateTime date, autorisation p)
        {

            var autorisation = ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.date == date).First();

            autorisation.date = p.date;
            autorisation.matricule = p.matricule;
            autorisation.nomprenom = p.nomprenom;
            autorisation.nbrheure = p.nbrheure;
            autorisation.description = p.description;
            autorisation.payer = p.payer;

            ChoixBD.MyDbContext.SaveChanges();

            return Ok(p);
        }


        // -------------------------------- Partie Admin ----------------------------------------------







        [HttpPut, ActionName("PutAutorisationAccepter")]
        [Route("PutAutorisationAccepter")]
        public IHttpActionResult PutAutorisationAccepter(String matricule, DateTime date)
        {
            var existingconge = ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.matricule == matricule && c.date == date).First();
            existingconge.etat = "A";

            ChoixBD.MyDbContext.SaveChanges();


            return Ok(existingconge);
        }


        [HttpPut, ActionName("PutAutorisationRefuser")]
        [Route("PutAutorisationRefuser")]
        public IHttpActionResult PutAutorisationRefuser(String matricule, DateTime date)
        {
            var existingconge = ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.matricule == matricule && c.date == date).First();
            existingconge.etat = "R";

            ChoixBD.MyDbContext.SaveChanges();


            return Ok(existingconge);
        }


        [HttpGet, ActionName("GetAllAutorisationAccepter")]
        [Route("GetAllAutorisationAccepter")]
        public IEnumerable<autorisation> GetAllCongeAccepter()
        {

            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.etat == "A").ToList();

        }

        [HttpGet, ActionName("GetAllAutorisationRefuser")]
        [Route("GetAllAutorisationRefuser")]
        public IEnumerable<autorisation> GetAllCongeRefuser()
        {

            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.etat == "R").ToList();

        }

        [HttpGet, ActionName("GetAllCongeEnAttente")]
        [Route("GetAllCongeEnAttente")]
        public IEnumerable<autorisation> GetAllCongeEnAttente()
        {

            return ChoixBD.MyDbContext.Set<autorisation>().Where(c => c.etat == "E").ToList();

        }





    }
}
