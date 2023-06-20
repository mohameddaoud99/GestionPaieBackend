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
using System.Net.Mail;

namespace PaieBack.Controllers
{
    [RoutePrefix("api/Personnel")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class PersonnelController : ApiController
    {
         userpaieEntities userpaie = new userpaieEntities();


        [HttpPost, ActionName("Postuserpaie")]
        [Route("Postuserpaie")]
        public IHttpActionResult Postuserpaie(utilisateur p,string email)
        {
           
                var utilisateur = new utilisateur();
                int matr = userpaie.Set<utilisateur>().Select(utilisateurcompteuser => new { compteuser = utilisateurcompteuser.compteuser, }).ToList().Count() + 1;

            string to = email;

            MailMessage mm = new MailMessage();

            mm.From = new MailAddress("SfaxSociete@gmail.com");
            mm.To.Add(to);

            mm.Subject = "Confirmation d'inscription réussie";

            mm.Body = "<html>" +
                "<body>" +
                "<p>Bonjour <b>"  + "</b></p>" +
                "" +
                "Nous sommes heureux de vous informer que votre compte a été créé avec succès . En tant que nouvel employé de notre entreprise, vous aurez maintenant accès à toutes les fonctionnalités du site." +
                "<br>Vos informations de connexion sont les suivantes: <br>" +
                "<h3> Code de compte user: " + "0" + matr.ToString() + "</h3>" +
                 "<h3>Mot de passe : " + p.motdepasse + "</h3>" +
                 "Si vous avez des questions ou des problèmes, n'hésitez pas à contacter notre équipe de support à l'adresse suivante : <b>sfaxsociete@gmail.com</b> ." +
                 "<br>Nous espérons que vous apprécierez l'utilisation de notre site web et que vous vous y sentirez à l'aise. Bienvenue dans notre équipe " +
                 "<br><br>Cordialement"
                 + "</body></html>";

            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");


            smtp.UseDefaultCredentials = true;

            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("SfaxSociete@gmail.com", "bbxgyidifhsmdleo");
            smtp.Send(mm);


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
        public IHttpActionResult Putuserpaie(string motdepasse, utilisateur u)
        {

       
            var utilisateur = userpaie.Set<utilisateur>().Where(c => c.motdepasse == motdepasse).First();


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
                        SALB =employee.SALB,
                        TXCNSS = employee.TXCNSS,
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
                 //personnel.SALB = p.SALB;
                 //personnel.TXCNSS = p.TXCNSS;
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
                 personnel.SALB= p.SALB;
                 personnel.TIT= "";
                 personnel.SITF= "";
                 personnel.TXHOR= null;
                 personnel.TXCNSS= p.TXCNSS;
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


           /* List<majconge> mcList = ChoixBD.MyDbContext.Set<majconge>()
       .Where(x => x.matricule.Equals(MATR))
       .ToList();

            if (mcList.Count == 0)
            {
                return NotFound();
            }

            List<autorisation> autList = ChoixBD.MyDbContext.Set<autorisation>()
                .Where(x => x.matricule.Equals(MATR))
                .ToList();

            if (autList.Count == 0)
            {
                return NotFound();
            }

            foreach (var mc in mcList)
            {
                ChoixBD.MyDbContext.Set<majconge>().Remove(mc);
            }

            foreach (var aut in autList)
            {
                ChoixBD.MyDbContext.Set<autorisation>().Remove(aut);
            }
           */

            //utilisateur userpai = userpaie.Set<utilisateur>().Where(c => c.motdepasse == MATR).First();
            // userpaie.Set<utilisateur>().Remove(userpai);


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
            personnel.SALB = p.SALB;
            personnel.TXCNSS = p.TXCNSS;
            personnel.nbmois = p.nbmois;
            personnel.email = p.email;

            ChoixBD.MyDbContext.SaveChanges();
            
            return Ok(p);
        }
    }
}
