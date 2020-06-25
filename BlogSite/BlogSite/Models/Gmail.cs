using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Gmail
    {
        [Required(ErrorMessage = "Ad Soyad gereklidir.")]
        public string adsoyad { get; set; }
        public string konu { get; set; }

        [Required(ErrorMessage = "Email gereklidir.")]
        [EmailAddress(ErrorMessage ="Adres geçersiz!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mesaj gereklidir.")]
        [MaxLength(500, ErrorMessage = "500 karakteri geçmeyin")]
        public string mesaj { get; set; }
        public string ip { get; set; }

    }
}