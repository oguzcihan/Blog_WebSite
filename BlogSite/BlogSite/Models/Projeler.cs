using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Projeler
    {
        public int Id { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeDili { get; set; }
        public bool ProjelerSol { get; set; }
        public bool ProjelerSag { get; set; }
        public DateTime EklemeTarih { get; set; }
        public string Detay { get; set; }
        public string Url { get; set; }
        public string Resim { get; set; }

        public List<Projeler> Proje { get; set; }
    }
}