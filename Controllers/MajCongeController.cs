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
    [RoutePrefix("api/MajCoge")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MajCongeController : ApiController
    {
        [HttpGet, ActionName("GetMajCoge")]
        [Route("GetMajCoge")]
        public object GetMajCoge()
        { 
            return ChoixBD.MyDbContext.Set<majconge>().ToList();
        }

        [HttpGet, ActionName("GetMajCogeUtilisateur")]
        [Route("GetMajCogeUtilisateur")]
        public object GetMajCogeUtilisateur(string matricule, string nomprenom)
        {
            return ChoixBD.MyDbContext.Set<majconge>()
                .Where(x => x.matricule.Equals(matricule) && x.nomprenom.Equals(nomprenom) && x.etat == "E")
                .ToList();
        }

        [HttpGet, ActionName("GetCongesAccepterByIdE")]
        [Route("GetCongesAccepterByIdE")]
        public IEnumerable<majconge> GetCongesAccepterByIdEmployee(string matricule)
        {
            return ChoixBD.MyDbContext.Set<majconge>().Where(c => c.matricule == matricule && c.etat == "A").ToList();
        }


        [HttpGet, ActionName("GetCongesRefuserByIdE")]
        [Route("GetCongesRefuserByIdE")]
        public IEnumerable<majconge> GetCongesRefuserByIdE(string matricule)
        {
            return ChoixBD.MyDbContext.Set<majconge>().Where(c => c.matricule == matricule && c.etat == "R").ToList();
        }




        // POST: api/MajCoge
        [ResponseType(typeof(majconge))]
        public HttpResponseMessage PostMajCoge(majconge p)
        {


            if (ModelState.IsValid)
            {
                var majconge = new majconge();

                majconge.code = p.code;
                majconge.libelle = p.libelle;
                majconge.type = p.type;
                DateTime dateDebut = p.datedepart;
                DateTime dateF = (DateTime)p.datefin;
                TimeSpan nombreDeJours = dateF - dateDebut;
                majconge.nbrjour = nombreDeJours.Days;

                int dureeTotaleEnHeuresParJour = 8;
                int nombreTotalDHeures = nombreDeJours.Days * dureeTotaleEnHeuresParJour;


                majconge.nbrheure = nombreTotalDHeures;

                majconge.matricule = p.matricule;
                majconge.nomprenom = p.nomprenom;

                majconge.solde = 0;
                majconge.datedepart = p.datedepart;
                majconge.datefin = p.datefin;
                majconge.payer = null;

                majconge.description = p.description;
                majconge.etat = "E";


                ChoixBD.MyDbContext.Set<majconge>().Add(majconge);
                ChoixBD.MyDbContext.SaveChanges();


                // return Ok(new { status = 200, isSuccess = true, message = "Ajouter Existe", Details = p });
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, p);
               
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

        [HttpDelete, ActionName("DeleteMajCogeUtilisateur")]
        [Route("DeleteMajCogeUtilisateur")]
        public IHttpActionResult DeleteMajCogeUtilisateur(string matricule, string nomprenom, DateTime datedepart)
        {
            majconge mc= ChoixBD.MyDbContext.Set<majconge>()
                .Where(x => x.matricule.Equals(matricule) && x.nomprenom.Equals(nomprenom) &&  x.datedepart.Equals(datedepart))
                .First();
            if (mc == null)
            {
                return NotFound();
            }

            ChoixBD.MyDbContext.Set<majconge>().Remove(mc);
            ChoixBD.MyDbContext.SaveChanges();
            return Ok(mc);
        }

        // PUT: api/Personnel?MATR=000167
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajCoge(DateTime datedepart,majconge p)
        {

            var majconge = ChoixBD.MyDbContext.Set<majconge>().Where(c => c.datedepart == datedepart).First();


 

            majconge.code = p.code;
            majconge.libelle = p.libelle;
            majconge.type = p.type;

            majconge.matricule = p.matricule;
            majconge.nomprenom = p.nomprenom;

           

            majconge.datefin = p.datefin;

            DateTime dateDebut = datedepart;
            DateTime dateF = (DateTime)p.datefin;
            TimeSpan nombreDeJours = dateF - dateDebut;
            majconge.nbrjour = nombreDeJours.Days;
            int nombreDeJour = nombreDeJours.Days;

            int dureeTotaleEnHeuresParJour = 8;
            int nombreTotalDHeures = nombreDeJour * dureeTotaleEnHeuresParJour;


            majconge.nbrheure = nombreTotalDHeures;



            majconge.description = p.description;

            ChoixBD.MyDbContext.SaveChanges();

            return Ok(p);
        }

        [HttpPut, ActionName("PutAccepter")]
        [Route("PutAccepter")]
        public IHttpActionResult PutAccepter(DateTime datedepart)
        {
            var existingconge = ChoixBD.MyDbContext.Set<majconge>().Where(c => c.datedepart == datedepart).First();
            existingconge.etat = "A";

                ChoixBD.MyDbContext.SaveChanges();
            
           
            return Ok(existingconge);
        }


        [HttpPut, ActionName("PutCongeRefuser")]
        [Route("PutCongeRefuser")]
        public IHttpActionResult PutCongeRefuser(DateTime datedepart)
        {
            var existingconge = ChoixBD.MyDbContext.Set<majconge>().Where(c => c.datedepart == datedepart).First();
            existingconge.etat = "R";

            ChoixBD.MyDbContext.SaveChanges();


            return Ok(existingconge);
        }

        // DELETE:/api/Personnel?MATR=2023-04-13
        [HttpDelete]
        public IHttpActionResult DeleteMajCoge(DateTime datedepart)
        {
            majconge maj = ChoixBD.MyDbContext.Set<majconge>().Where(c => c.datedepart == datedepart).First();
            if (maj == null)
            {
                return NotFound();
            }

            ChoixBD.MyDbContext.Set<majconge>().Remove(maj);
            ChoixBD.MyDbContext.SaveChanges();
            return Ok(maj);
        }


   

    }
}
