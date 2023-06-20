using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaieBack.Models
{
    public class Statistique
    {
        public int nbCongeMoisA { get; set; }
        public int nbCongeMoisR { get; set; }
        public int nbCongeMoisE { get; set; }

        public int nbAutorisationA { get; set; }
        public int nbAutorisationR { get; set; }
        public int nbAutorisationE { get; set; }

        public int nbCongeA { get; set; }
        public int nbCongeR { get; set; }
        public int nbCongeE { get; set; }
       

    }
}