using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaieBack.Models;
using System.Web.Http.Cors;
namespace PaieBack.Controllers
{
    [RoutePrefix("api/ChoixBD")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ChoixBDController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ChoixBaseDeDonner(string dbName)
        {
            if (dbName == "grpaie")
            {
                ChoixBD.MyDbContext?.Dispose(); 
                ChoixBD.MyDbContext = new grpaieEntities(); 
                return Ok("choix grpaie");
            }
            else if (dbName == "grpaie2")
            {
                ChoixBD.MyDbContext?.Dispose(); 
                ChoixBD.MyDbContext = new grpaie2Entities(); 
                return Ok("choix grpaie2");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
