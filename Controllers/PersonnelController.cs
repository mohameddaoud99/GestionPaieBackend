using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaieBack.Models;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Data.Entity.Infrastructure;

namespace PaieBack.Controllers
{
    [RoutePrefix("api/Personnel")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
/*teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeest*/
    public class PersonnelController : ApiController
    {
         userpaieEntities userpaie = new userpaieEntities();


        [HttpPost, ActionName("Postuserpaie")]
        [Route("Postuserpaie")]
        public IHttpActionResult Postuserpaie(utilisateur p)
        {
            

                var utilisateur = new utilisateur();
                int matr = userpaie.Set<utilisateur>().Select(utilisateurcompteuser => new { compteuser = utilisateurcompteuser.compteuser, }).ToList().Count() + 1;

                utilisateur.compteuser = "0" + matr.ToString();
                utilisateur.motdepasse = p.motdepasse;
                utilisateur.DERSOC = p.DERSOC;
                utilisateur.type = "Personnel";
                utilisateur.actif = "";
                utilisateur.numvol = "";

            try
            {
                userpaie.Set<utilisateur>().Add(utilisateur);
                userpaie.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();

            }
            //  return Ok(new { status = 200, isSuccess = true, message = "Ajouter", EmployeeDetails = utilisateur });
            return Ok(utilisateur);

        }

        [HttpPut, ActionName("Putuserpaie")]
        [Route("Putuserpaie")]
        public IHttpActionResult Putuserpaie(string compteuser, utilisateur u)
        {


       
            var utilisateur = userpaie.Set<utilisateur>().Where(c => c.compteuser == compteuser).First();


            utilisateur.motdepasse = u.motdepasse;
            

            try
            {
                userpaie.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();

            }

            return Ok(utilisateur);
        }

        [HttpGet, ActionName("Getuserpaie")]
        [Route("Getuserpaie")]
        public object Getuserpaie(String DERSOC)
        {

            return userpaie.Set<utilisateur>()
                    .Where(c => c.DERSOC == DERSOC).Select(utilisateur => new {
                        motdepasse = utilisateur.motdepasse,
                    }).ToList();
        }


        [HttpGet, ActionName("GetEmployee")]
        [Route("GetEmployee")]
        public IHttpActionResult GetEmployee(string CIN)
        {

           /* var user=  ChoixBD.MyDbContext.Set<personnel>().Where(c => c.CIN == Cin).Select(employee => new
            {

                NOMPRENOM1 = employee.NOMPRENOM1,
            }).ToList();
            return Ok(user);*/

            personnel pers = ChoixBD.MyDbContext.Set<personnel>().Where(c => c.CIN == CIN).First();
            if (pers == null)
            {
                return NotFound();
            }

            return Ok(pers);
        }

        [HttpGet, ActionName("mat")]
        [Route("mat")]
        public string mat()
        {
            return "000"+(ChoixBD.MyDbContext.Set<personnel>()
                    .Select(employee => new {
            
                        NOMPRENOM1 = employee.NOMPRENOM1,
                    }).ToList().Count()+3).ToString();
        
        }

        //GET:/api/Personnel/GetPersonnel
        public object GetPersonnel()
        {   
        
            return ChoixBD.MyDbContext.Set<personnel>()
                    .Select(employee => new {
                        MATR = employee.MATR,
                        NOMPRENOM1 = employee.NOMPRENOM1,
                        CIN = employee.CIN,
                        TELEPHONE = employee.TELEPHONE,
                        ADRESSE = employee.ADRESSE,
                        SEXE = employee.SEXE,
                        NAIS = employee.NAIS,

                        BANQUEPER = employee.BANQUEPER,
                        numcompte = employee.numcompte,
                        PAYEMENT = employee.PAYEMENT,
                        email = employee.email,
                        nbmois = employee.nbmois,
                        

        }).ToList();
        }

        // POST: api/Personnel
        [ResponseType(typeof(personnel))]
        public HttpResponseMessage Postpersonnel(personnel p)
        {
            if (ModelState.IsValid)
            {
 
                var personnel = new personnel();
                int matr = ChoixBD.MyDbContext.Set<personnel>().Select(employee => new { MATR = employee.MATR, }).ToList().Count() + 1;

                personnel.MATR = "0000" + matr.ToString();
                personnel.NOMPRENOM1 = p.NOMPRENOM1;
                personnel.CIN = p.CIN;
                personnel.TELEPHONE = p.TELEPHONE;
                personnel.ADRESSE = p.ADRESSE;
                personnel.SEXE = p.SEXE;
                personnel.NAIS = p.NAIS;

                personnel.email = p.email;

                 personnel.BANQUESTE = "ATTIJARI";
                 personnel.BANQUEPER = p.BANQUEPER;
                 personnel.numcompte = p.numcompte;
                 personnel.PAYEMENT = p.PAYEMENT;
                 personnel.nbmois = p.nbmois;


                 personnel.CAISSE= "";
                 personnel.ECHELON= "";
               
                 personnel.NATIONAL= "T";
                 personnel.TRV_AN= 0;
                 personnel.PRENOM1= null;
                 personnel.PRENOM2= null;
                 personnel.PRENOM3= null;
                 personnel.PRENOM4= null;
                 personnel.NBRENFANT= 2;
                 personnel.NUMCNSS= "";
                 personnel.SERV= "";
                 personnel.REGIME2= null;
                 
                 personnel.nomregime1= "";
                 personnel.SALB= null;
                 personnel.TIT= "";
                 personnel.SITF= "";
                 personnel.TXHOR= null;
                 personnel.TXCNSS= null;
                 personnel.NOMPRENOM2= "";
                
                 
                 personnel.DECIMPOT= "";
                 personnel.ARR1= 0;
                 personnel.COMPTEC= "";
                 personnel.ATELIER= "";
                 personnel.CAT= "";
                 personnel.CHEF= "";
                 personnel.PRESENCE= "";
                 personnel.QUAL= "";
                 personnel.AFF= "";
                 personnel.DATECHE= null;
                 personnel.PROCHEECHE= null;
                 personnel.EMBO= null;
                 
                 personnel.ACCtrv= null;
                 personnel.DATESIT= null;
                 personnel.NAIS1= null;
                 personnel.NAIS2= null;
                 personnel.NAIS3= null;
                 personnel.NAIS4= null;
                 personnel.imagepersonnel= "";
                 personnel.SMIG= "";
                 personnel.SUPH= "";
                 personnel.DATECIN= null;
                 personnel.SoldInit= 0.0;
                 personnel.DroitCong= 0.0;
                 personnel.Total= 0.0;
                 personnel.assurance= 0.0;
                 personnel.matpointeuse= "";
                 personnel.redevance= "0";
                
                 personnel.tfp= 0.0;
                 personnel.foprolos= 0.0;
                 personnel.comptecb= 0.0;
                 personnel.sel= "";
                 personnel.DateDepart= null;
                 personnel.imagepath= "";
                 personnel.image= null;
                 personnel.imagesize = 0;
              

                ChoixBD.MyDbContext.Set<personnel>().Add(personnel);
                ChoixBD.MyDbContext.SaveChanges();


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, personnel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = personnel.MATR }));
                return response;
        }
            else
            {
                 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            
        }

        // DELETE:/api/Personnel?MATR=555
        [HttpDelete]
        public IHttpActionResult DeleteConge(string MATR)
        {
            personnel pers = ChoixBD.MyDbContext.Set<personnel>().Where(c => c.MATR == MATR).First();
            if (pers == null)
            {
                return NotFound();
            }

            ChoixBD.MyDbContext.Set<personnel>().Remove(pers);
            ChoixBD.MyDbContext.SaveChanges();
            return Ok(pers);
        }

        // PUT: api/Personnel?MATR=000167
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConge(string MATR, personnel p)
        {

            var personnel = ChoixBD.MyDbContext.Set<personnel>().Where(c => c.MATR == MATR).First();

           
            personnel.NOMPRENOM1 = p.NOMPRENOM1;
            personnel.CIN = p.CIN;
            personnel.TELEPHONE = p.TELEPHONE;
            personnel.ADRESSE = p.ADRESSE;
            personnel.SEXE = p.SEXE;
            personnel.NAIS = p.NAIS;
            personnel.BANQUEPER = p.BANQUEPER;
            personnel.numcompte = p.numcompte;
            personnel.PAYEMENT = p.PAYEMENT;
            personnel.nbmois = p.nbmois;
            personnel.email = p.email;

            ChoixBD.MyDbContext.SaveChanges();
            
            return Ok(p);
        }
    }
}
