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
    
    public partial class autorisation
    {
        public Nullable<int> nbrheure { get; set; }
        public string matricule { get; set; }
        public string nomprenom { get; set; }
        public Nullable<float> solde { get; set; }
        public System.DateTime date { get; set; }
        public string payer { get; set; }
        public string description { get; set; }
        public string etat { get; set; }
    }
}
