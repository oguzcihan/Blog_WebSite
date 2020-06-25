using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    
    public class ProjelersController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Projelers
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Projeler.ToList());
        }

        // GET: Projelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // GET: Projelers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,ProjeAdi,ProjeDili,ProjelerSol,ProjelerSag,Detay,Url,Resim")] Projeler projeler,HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                if (extension == ".jpg" || extension == ".png")
                {
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/upload"), filename);
                    projeler.Resim = filename;
                    file.SaveAs(path);
                }
                else
                {
                    ViewData["Uyarı"] = "Dosya türünüz .jpg ve .png olmalıdır.";
                }
            }
            else
            {
                ViewData["Uyarı"] = "Dosya Seçmediniz";
            }
            if (ModelState.IsValid)
            {
                projeler.EklemeTarih = DateTime.Now;
                db.Projeler.Add(projeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projeler);
        }

        // GET: Projelers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,ProjeAdi,ProjeDili,ProjelerSol,ProjelerSag,Detay,Url,Resim")] Projeler projeler)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Projeler.Find(projeler.Id);
                if (entity != null)
                {
                    entity.ProjeAdi = projeler.ProjeAdi;
                    entity.ProjeDili = projeler.ProjeDili;
                    entity.ProjelerSag = projeler.ProjelerSag;
                    entity.ProjelerSol = projeler.ProjelerSol;
                    entity.Resim = projeler.Resim;
                    entity.Url = projeler.Url;
                    entity.Detay = projeler.Detay;
                }
                db.SaveChanges();
                return RedirectToAction("Index","Projelers");
            }
            return View(projeler);
        }

        // GET: Projelers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeler projeler = db.Projeler.Find(id);
            db.Projeler.Remove(projeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
