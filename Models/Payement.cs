using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaieBack.Models
{
    public class Payement
    {

        public int nbjours { get; set; }
        public int nbheures { get; set; }
        public int nbheuresaut { get; set; }
        public int salaireb { get; set; }
        public int salaireInit { get; set; }
        public int taxeCNSS { get; set; }
        public int montantEl { get; set; }
        public int montantElTaxe { get; set; }
        public int montantElAutorisation { get; set; }
        public int prixheure { get; set; }
        public string nomprenom{ get; set; }


    }
}