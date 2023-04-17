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

        // POST: api/MajCoge
        [ResponseType(typeof(majconge))]
        public IHttpActionResult PostMajCoge(majconge p)
        {
            /*  if (ModelState.IsValid)
              {

                  var majconge = new majconge();

                  majconge.code =  p.code;
                  majconge.libelle = p.libelle;
                  majconge.type = p.type;
                  majconge.nbrjour = p.nbrjour;
                  majconge.nbrheure = p.nbrheure;
                  majconge.matricule = p.matricule;

                  majconge.nomprenom = p.nomprenom;
                  majconge.solde = p.solde;
                  majconge.datedepart = p.datedepart;
                  majconge.datefin = p.datefin;
                  majconge.payer = "";
                  majconge.description = p.description;


                  ChoixBD.MyDbContext.Set<majconge>().Add(majconge);
                  ChoixBD.MyDbContext.SaveChanges();


                  return Ok(majconge);
              }
              else
              {
                  return NotFound();
              }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ChoixBD.MyDbContext.Set<majconge>().Add(p);
            ChoixBD.MyDbContext.SaveChanges();

            return Ok(new { status = 200, isSuccess = true, message = "Ajouter Existe", Details = p });


        }


        // PUT: api/Personnel?MATR=000167
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajCoge(DateTime datedepart,majconge p)
        {

            var majconge = ChoixBD.MyDbContext.Set<majconge>().Where(c => c.datedepart == datedepart).First();


            majconge.code = p.code;
            majconge.libelle = p.libelle;
            majconge.type = p.type;
            majconge.nbrjour = p.nbrjour;
            majconge.nbrheure = p.nbrheure;
            majconge.solde = p.solde;
            majconge.datefin = p.datefin;
            majconge.payer = "";
            majconge.description = p.description;


            ChoixBD.MyDbContext.SaveChanges();

            return Ok(p);
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
