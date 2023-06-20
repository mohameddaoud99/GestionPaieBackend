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

        // getAll 
        [HttpGet, ActionName("GetAllCongeEnAttante")]
        [Route("GetAllCongeEnAttante")]
        public IEnumerable<majconge> GetAllCongeEnAttante()
        {
            return ChoixBD.MyDbContext.Set<majconge>().Where(c => c.etat == "E").ToList();
        }


        [HttpGet, ActionName("GetUtilisateur")]
        [Route("GetUtilisateur")]
        public object GetUtilisateur(string CIN)
        {
            return ChoixBD.MyDbContext.Set<personnel>()

                .Where(x => x.CIN.Equals(CIN))
                 .Select(personnel => new
                 {
                     MATR = personnel.MATR,
                     NOMPRENOM1 = personnel.NOMPRENOM1
                 })
                .ToList();
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

        [HttpPost, ActionName("PostMajCogePartieAdmin")]
        [Route("PostMajCogePartieAdmin")]
        public HttpResponseMessage PostMajCogePartieAdmin(majconge p)
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
                majconge.etat = "A";


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
            majconge mc = ChoixBD.MyDbContext.Set<majconge>()
                .Where(x => x.matricule.Equals(matricule) && x.nomprenom.Equals(nomprenom) && x.datedepart.Equals(datedepart))
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
        public IHttpActionResult PutMajCoge(DateTime datedepart, majconge p)
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

        [HttpGet, ActionName("GetAllCongeAccepter")]
        [Route("GetAllCongeAccepter")]
        public IEnumerable<majconge> GetAllCongeAccepter()
        {

            return ChoixBD.MyDbContext.Set<majconge>().Where(c => c.etat == "A").ToList();

        }

        [HttpGet, ActionName("GetAllCongeRefuser")]
        [Route("GetAllCongeRefuser")]
        public IEnumerable<majconge> GetAllCongeRefuser()
        {

            return ChoixBD.MyDbContext.Set<majconge>().Where(c => c.etat == "R").ToList();

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



      


        [HttpGet, ActionName("Dali")]
        [Route("Dali")]
        public HttpResponseMessage Dali(String mat, int month, DateTime startDate, DateTime endDate)
        {

            //DateTime startDate = new DateTime(2023, 5, 1);
            //DateTime endDate = new DateTime(2023, 5, 30);

            var xx = ChoixBD.MyDbContext.Set<majconge>()
                .Where(x => x.matricule.Equals(mat) && x.etat.Equals("A") &&
           (x.datedepart >= startDate && x.datedepart <= endDate ||
            x.datefin >= startDate && x.datefin <= endDate))
                .Select(majconge => new
                {
                    DateDebut = majconge.datedepart,
                    DateFin = majconge.datefin,
                    NOMPRENOM1 = majconge.nomprenom,
                })
                .ToList();

            var yy = ChoixBD.MyDbContext.Set<personnel>()
               .Where(x => x.MATR.Equals(mat))
                 .Select(personnel => new
                 {
                     SALB = personnel.SALB,
                     TXCNSS = personnel.TXCNSS,
                     NOMPRENOM1 = personnel.NOMPRENOM1
                 })
                .ToList();

            var zz = ChoixBD.MyDbContext.Set<autorisation>()
                .Where(x => x.matricule.Equals(mat) && x.etat.Equals("A") &&
                      x.date.Month == month)


                .Select(autorisation => new
                {
                    nbheuresaut = autorisation.nbrheure

                })
                .ToList();


            int nbTOT = 0;
            int nbheuresauto = 0;
            float salaireb = 0;
            int taxeCNSS = 0;
            int prixheure = 5;
            string nomprenom = "";

            if (ModelState.IsValid)
            {
                foreach (var ind in xx)
                {

                    if (ind.DateDebut.Month == Convert.ToDateTime(ind.DateFin).Month)
                    {
                        nbTOT = nbTOT + Convert.ToInt32(Convert.ToDateTime(ind.DateFin).Day - ind.DateDebut.Day) + 1;
                    }

                    else if (month == ind.DateDebut.Month && month != Convert.ToDateTime(ind.DateFin).Month)
                    {
                        int DayInMonth = DateTime.DaysInMonth(ind.DateDebut.Year, month);
                        nbTOT = nbTOT + DayInMonth - Convert.ToInt32(ind.DateDebut.Day) + 1;

                    }
                    else
                    {
                        nbTOT = nbTOT + Convert.ToInt32(Convert.ToDateTime(ind.DateFin).Day);


                    }
                }
                foreach (var ind in yy)
                {
                    salaireb = (float)ind.SALB;
                    taxeCNSS = (int)ind.TXCNSS;
                    nomprenom = ind.NOMPRENOM1;
                }


                foreach (var ind in zz)
                {
                    nbheuresauto = nbheuresauto + (int)ind.nbheuresaut;
                }


                int solde = nbTOT * 8;
                int montantEl = solde * prixheure;
                int montantElTaxe = (int)((salaireb * taxeCNSS) / 100);
                int montantElAutorisation = nbheuresauto * prixheure;
                int montantElAutorisaon = nbheuresauto * prixheure;
                int SalInit = (int)salaireb;
                salaireb = (int)(salaireb - (montantEl + (salaireb * taxeCNSS) / 100) - montantElAutorisaon);

                List<string> myStrings = new List<string>();
                myStrings.Add(nomprenom);

                List<int> myIntegers = new List<int>();
                myIntegers.Add(nbTOT);
                myIntegers.Add(solde);
                myIntegers.Add((int)salaireb);
                myIntegers.Add(taxeCNSS);
                myIntegers.Add(montantEl);
                myIntegers.Add(nbheuresauto);
                myIntegers.Add(prixheure);
                myIntegers.Add(montantElAutorisation);
                myIntegers.Add(montantElTaxe);
                myIntegers.Add(SalInit);



                var payement = new Payement();
                payement.nbjours = myIntegers[0];
                payement.nbheures = myIntegers[1];
                payement.nbheuresaut = myIntegers[5];
                payement.prixheure = myIntegers[6];
                payement.salaireb = myIntegers[2];
                payement.salaireInit = myIntegers[9];
                payement.taxeCNSS = myIntegers[3];
                payement.montantEl = myIntegers[4];
                payement.montantElAutorisation = myIntegers[7];
                payement.montantElTaxe = myIntegers[8];
                payement.nomprenom = myStrings[0];
               

                


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, payement);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }


    }
}
