using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string altBaslik { get; set; }

        [AllowHtml]
        public string Icerik { get; set; }
        public string Sonuc { get; set; }
        public bool Anasayfa { get; set; }
        public bool AnasayfaSag { get; set; }
        public string Resim { get; set; }
        public DateTime EklemeTarih { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}