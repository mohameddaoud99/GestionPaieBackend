using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace PaieBack.Models
{
    public class ChoixBD
    {
        public static DbContext MyDbContext { get; set; }
    }
}