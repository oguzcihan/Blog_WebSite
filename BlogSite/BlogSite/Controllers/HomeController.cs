using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
        // GET: Home

        [Authorize]
        public ActionResult Index()
        {
            
            return View(context.Bloglar.ToList());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = context.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Gmail model)
        {
            string ip,name;
            ip = Request.UserHostAddress;
            name = Request.UserHostName;

            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse( ConfigurationManager.AppSettings["port"]);
            bool ssl= ConfigurationManager.AppSettings["ssl"].ToString()=="1"? true : false;
            string from= ConfigurationManager.AppSettings["from"];
            string password = ConfigurationManager.AppSettings["password"];
            string fromname = ConfigurationManager.AppSettings["fromname"];
            string to= ConfigurationManager.AppSettings["to"];

            var client = new SmtpClient();
            client.Host = server;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from,password);

            var mail = new MailMessage();
            mail.SubjectEncoding = Encoding.Default;
            mail.BodyEncoding = Encoding.Default;
            mail.HeadersEncoding=Encoding.Default;
            mail.From = new MailAddress(from, fromname);
            mail.To.Add(to);

            mail.Subject = model.konu;
            mail.IsBodyHtml = true;
            mail.Body = $"Ad Soyad: {model.adsoyad} \n Konu: {model.konu} \n Mesaj: {model.mesaj} \n E-Posta: {model.email} \n Ip: {ip}  \n Hostname: {name}";
            if (model.email != null&&model.adsoyad!=null&&model.konu!=null&&model.mesaj!=null)
            {
                client.Send(mail);
                TempData["result"] = "Mesajınız gönderildi en kısa sürede dönüş yapılacaktır.";
            }
            else
            {
                TempData["error"] = "Hata";
            }
         
           
            return View();
          
        }
       
        public ActionResult Projeler()
        {
            return View(context.Projeler.ToList());
        }


        [Authorize]
        public ActionResult _admin()
        {
            return View(context.Bloglar.ToList());
        }

      
    }
}