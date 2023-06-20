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
    [RoutePrefix("api/Payement")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PayementController : ApiController
    {

        [HttpGet, ActionName("affiche")]
        [Route("affiche")]
        public object affiche(string mat)
        {
            DateTime startDate = new DateTime(2023,06,01);
            DateTime endDate = new DateTime(2023,06,30);

            return ChoixBD.MyDbContext.Set<majconge>()
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
        }

        [HttpGet, ActionName("afficheTEST")]
        [Route("afficheTEST")]
        public object afficheTEST(string mat)
        {
            DateTime startDate = new DateTime(2023, 06, 01);
            DateTime endDate = new DateTime(2023, 06, 30);

            return ChoixBD.MyDbContext.Set<majconge>()
                .Where(x => x.matricule.Equals(mat) && x.etat.Equals("A") &&
                       x.datedepart >= startDate &&
                       x.datedepart <= endDate ||
                       x.datefin >= startDate &&
                       x.datefin <= endDate)
                .Select(majconge => new
                {
                    DateDebut = majconge.datedepart,
                    DateFin = majconge.datefin,
                    NOMPRENOM1 = majconge.nomprenom,
                })
                .ToList();
        }

        [HttpGet, ActionName("afficheAutorisation")]
        [Route("afficheAutorisation")]
        public object afficheAutorisation(string mat)
        {

           return ChoixBD.MyDbContext.Set<personnel>()
                .Where(x => x.MATR.Equals(mat))
                  .Select(personnel => new
                  {
                      SALB = personnel.SALB,
                      TXCNSS = personnel.TXCNSS,
                      NOMPRENOM1 = personnel.NOMPRENOM1
                  })
                 .ToList();
        }



        [HttpGet, ActionName("afficheSlaire")]
        [Route("afficheSlaire")]
        public object afficheSlaire(string mat)
        {
            return ChoixBD.MyDbContext.Set<personnel>()
               .Where(x => x.MATR.Equals(mat))
                 .Select(personnel => new
                 {
                     SALB = personnel.SALB,
                     TXCNSS = personnel.TXCNSS,
                     NOMPRENOM1 = personnel.NOMPRENOM1
                 })
                .ToList();
        }




        [HttpGet, ActionName("Dali")]
        [Route("Dali")]
        public HttpResponseMessage Dali(String mat, int month, DateTime startDate, DateTime endDate)
        {

            //DateTime startDate = new DateTime(2023, 5, 1);
            //DateTime endDate = new DateTime(2023, 5, 30);

            var xx = ChoixBD.MyDbContext.Set<majconge>()
               .Where(x => x.matricule.Equals(mat) && x.etat.Equals("A") &&
                       x.datedepart >= startDate &&
                       x.datedepart <= endDate ||
                       x.datefin >= startDate &&
                       x.datefin <= endDate)
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
                     TXCNSS =personnel.TXCNSS,
                     NOMPRENOM1 = personnel.NOMPRENOM1
                 }) 
                .ToList();

            var zz= ChoixBD.MyDbContext.Set<autorisation>()
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
                }


                foreach (var ind in zz)
                {
                    nbheuresauto = nbheuresauto+(int)ind.nbheuresaut;
                }


                int solde = nbTOT * 8;
                int montantEl = solde * prixheure;
                int montantElAutorisaon = nbheuresauto * prixheure;
                salaireb = (int)(salaireb - (montantEl + (salaireb * taxeCNSS) / 100)- montantElAutorisaon);

                List<int> myStrings = new List<int>();
                myStrings.Add(nbTOT);
                myStrings.Add(solde);
                myStrings.Add((int)salaireb);
                myStrings.Add(taxeCNSS);
                myStrings.Add(montantEl);
                myStrings.Add(nbheuresauto);
                myStrings.Add(prixheure);


                var payement = new Payement();
                payement.nbjours = myStrings[0];
                payement.nbheures = myStrings[1];
                payement.nbheuresaut = myStrings[5];
                payement.prixheure = myStrings[6];
                payement.salaireb = myStrings[2];
                payement.taxeCNSS = myStrings[3];
                payement.montantEl = myStrings[4];


                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, payement);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        /*
                if (dateStart.month == dateEnd.month)
                    {
                        day2-day1
                    }

                else if(MonthARechercher == dateStart.month )
                    {
                        decalage =datetime.dayInMonth-(dateStart.day+nbjours)
                        nbjourMonthARechercher = nbjours-decalage
                    }
               else
                    {
                        decalage = dateStart.day
                        nbjourMonthARechercher=decalage

                    }

                return ..........
        */






    }

}
