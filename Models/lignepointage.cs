//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaieBack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class lignepointage
    {
        public string Matr { get; set; }
        public string Nomprenom { get; set; }
        public string regime { get; set; }
        public Nullable<float> jourtrv { get; set; }
        public Nullable<float> heuretrv { get; set; }
        public Nullable<float> Jourcong { get; set; }
        public Nullable<float> jourfer { get; set; }
        public string codfich { get; set; }
        public string codchantier { get; set; }
        public string annee { get; set; }
        public string mois { get; set; }
        public string confirme { get; set; }
        public Nullable<double> hcong { get; set; }
        public Nullable<double> hfer { get; set; }
        public Nullable<double> tfp { get; set; }
        public Nullable<double> foprolos { get; set; }
    }
}
