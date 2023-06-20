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
    [RoutePrefix("api/Statistique")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatistiqueController : ApiController
    {

       




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


        [HttpGet, ActionName("NbCongeParMoisRefuse")]
        [Route("NbCongeParMoisRefuse")]
        public object NbCongeParMoisRefuse()
        {
            DateTime currentDate = DateTime.Now;
            return ChoixBD.MyDbContext.Set<majconge>()



                .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "R")

                .Select(majconge => majconge.code)
                .Count();
        }

        [HttpGet, ActionName("NbCongeParMoisEnAttente")]
        [Route("NbCongeParMoisEnAttente")]
        public object NbCongeParMoisEnAttente()
        {
            DateTime currentDate = DateTime.Now;
            return ChoixBD.MyDbContext.Set<majconge>()



                .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "E")

                .Select(majconge => majconge.code)
                .Count();
        }

        [HttpGet, ActionName("NbAutorisationA")]
        [Route("NbAutorisationA")]
        public object NbAutorisationA()
        {
            DateTime currentDate = DateTime.Now;
            return ChoixBD.MyDbContext.Set<autorisation>()

                .Where(x => x.date.Month == currentDate.Month && x.etat == "A")

                .Select(majconge => majconge.date)
                .Count();
        }

        [HttpGet, ActionName("NbAutorisationR")]
        [Route("NbAutorisationR")]
        public object NbAutorisationR()
        {
            DateTime currentDate = DateTime.Now;
            return ChoixBD.MyDbContext.Set<autorisation>()

                .Where(x => x.date.Month == currentDate.Month && x.etat == "R")

                .Select(majconge => majconge.date)
                .Count();
        }

        [HttpGet, ActionName("NbAutorisationEnAttente")]
        [Route("NbAutorisationEnAttente")]
        public object NbAutorisationEnAttente()
        {
            DateTime currentDate = DateTime.Now;
            return ChoixBD.MyDbContext.Set<autorisation>()

                .Where(x => x.date.Month == currentDate.Month && x.etat == "E")

                .Select(majconge => majconge.date)
                .Count();
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        [HttpGet, ActionName("StatistiqueInfos")]
        [Route("StatistiqueInfos")]
        public object StatistiqueInfos()
        {
            DateTime currentDate = DateTime.Now;

            var NbCongeParMoisAccepte = ChoixBD.MyDbContext.Set<majconge>()

                .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "A")

                .Select(majconge => majconge.code)
                .Count();

            var NbCongeParMoisRefuse = ChoixBD.MyDbContext.Set<majconge>()

                .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "R")

                .Select(majconge => majconge.code)
                .Count();

            var NbCongeParMoisEnAttente = ChoixBD.MyDbContext.Set<majconge>()

                .Where(x => x.datedepart.Month == currentDate.Month && x.etat == "E")

                .Select(majconge => majconge.code)
                .Count();


            var NbAutorisationA= ChoixBD.MyDbContext.Set<autorisation>()

                .Where(x => x.date.Month == currentDate.Month && x.etat == "A")

                .Select(autorisation => autorisation.date)
                .Count();

            var NbAutorisationR = ChoixBD.MyDbContext.Set<autorisation>()

               .Where(x => x.date.Month == currentDate.Month && x.etat == "R")

               .Select(autorisation => autorisation.date)
               .Count();

            var NbAutorisationEnAttente = ChoixBD.MyDbContext.Set<autorisation>()

               .Where(x => x.date.Month == currentDate.Month && x.etat == "E")

               .Select(autorisation => autorisation.date)
               .Count();



            var xx = ChoixBD.MyDbContext.Set<majconge>()
              .Where(x =>  x.etat == "A")

                .Select(majconge => majconge.etat)
                .Count();

            var yy = ChoixBD.MyDbContext.Set<majconge>()
              .Where(x => x.etat == "R")

                .Select(majconge => majconge.etat)
                .Count();

            var zz = ChoixBD.MyDbContext.Set<majconge>()
              .Where(x => x.etat == "E")

                .Select(majconge => majconge.etat)
                .Count();

            var xyz = ChoixBD.MyDbContext.Set<majconge>()
   
                .Select(majconge => majconge.etat)
                .Count();

            int NbCongeMoisAccepte = NbCongeParMoisAccepte;
            int NbCongeMoisRefuser = NbCongeParMoisRefuse;
            int NbCongeMoisAttente = NbCongeParMoisEnAttente;

            int NbAutorisationMoisAccepte = NbAutorisationA;
            int NbAutorisationMoisRefuse = NbAutorisationA;
            int NbAutorisationMoisAttente = NbAutorisationEnAttente;


            int nbCongeA = (xx *100)/xyz;
            int nbCongeR = (yy * 100) / xyz;
            float nbCongeE = (zz * 100) / xyz;

            if (ModelState.IsValid)
            {
                List<int> myStrings = new List<int>();

                myStrings.Add(NbCongeMoisAccepte);
                myStrings.Add(NbCongeMoisRefuser);
                myStrings.Add(NbCongeMoisAttente);

                myStrings.Add(NbAutorisationMoisAccepte);
                myStrings.Add(NbAutorisationMoisRefuse);
                myStrings.Add(NbAutorisationMoisAttente);

                myStrings.Add(nbCongeA);
                myStrings.Add(nbCongeR);
                myStrings.Add((int)nbCongeE);

                var stat = new Statistique();
                stat.nbCongeMoisA = myStrings[0];
                stat.nbCongeMoisR = myStrings[1];
                stat.nbCongeMoisE = myStrings[2];

                stat.nbAutorisationA = myStrings[3];
                stat.nbAutorisationR = myStrings[4];
                stat.nbAutorisationE = myStrings[5];

                stat.nbCongeA = myStrings[6];
                stat.nbCongeR = myStrings[7];
                stat.nbCongeE = myStrings[8];

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, stat);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }





        





    }
}