using PaieBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PaieBack.Controllers
{
    [RoutePrefix("api/Login")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        userpaieEntities userpaie = new userpaieEntities();


        [HttpPost, ActionName("LoginAdmin")]
        [Route("LoginAdmin")]
        public IHttpActionResult LoginAdmin(utilisateur loginDto)
        {
            var user = userpaie.utilisateur.Where(x => x.compteuser.Equals(loginDto.compteuser) && x.motdepasse.Equals(loginDto.motdepasse)).FirstOrDefault();
            if (user == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid Admin", });
            }
            else
            {
                return Ok(new { status = 200, isSuccess = true, message = "Admin Login successfully", AdminDetails = user });
            }

        }


        [HttpGet, ActionName("GetSocieteByUser")]
        [Route("GetSocieteByUser")]
        public object GetCongesRefuserByIdE(String user)
        {
            return userpaie.usersoc.Where(i => i.CODEUSER.Equals(user)).ToList();
        }

        [HttpGet, ActionName("choix")]
        [Route("choix")]
        public object choix(string CODEUSER)
        {

            var query = userpaie.usersoc
                .Join(userpaie.societe,
                    tabusersoc => tabusersoc.societe,
                    tabsociete => tabsociete.CODSOC,
                    (tabusersoc, tabsociete) => new { usersoc = tabusersoc, tabsersoc = tabsociete })
                .Where(societeAndusersoc => societeAndusersoc.usersoc.CODEUSER == CODEUSER)
                .Select(societeAndusersoc => new {
                    CODEUSER = societeAndusersoc.usersoc.CODEUSER,
                    NOMSOCI = societeAndusersoc.tabsersoc.NOMSOCI,
                    CODSOC = societeAndusersoc.tabsersoc.CODSOC,
                });
            return query;
        }


    }
}