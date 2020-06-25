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
    public class BlogsController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int id)
        {
            var bloglar = db.Bloglar.Where(i => i.CategoryId == id);
            bloglar = bloglar.Include(b => b.Category);
            return View(bloglar.ToList());
        }
        public ActionResult Liste(int id)
        {
            var bloglar = db.Bloglar.Where(i => i.CategoryId == id);
            bloglar = bloglar.Include(b => b.Category);
            return View(bloglar.ToList());
        }
        // GET: Blogs
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category);
            return View(bloglar.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Baslik,altBaslik,Icerik,Sonuc,Anasayfa,AnasayfaSag,Resim,CategoryId")] Blog blog, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                if (extension == ".jpg" || extension == ".png")
                {
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/upload"), filename);
                    blog.Resim = filename;
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
                blog.EklemeTarih = DateTime.Now;

                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Baslik,altBaslik,Icerik,Sonuc,Anasayfa,AnasayfaSag,Resim,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.altBaslik = blog.altBaslik;
                    
                    entity.Icerik = blog.Icerik;
                    entity.Sonuc = blog.Sonuc;
                    entity.Resim = blog.Resim;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.AnasayfaSag = blog.AnasayfaSag;
                    entity.CategoryId = blog.CategoryId;
                    blog.EklemeTarih = DateTime.Now;

                }
                db.SaveChanges();
                TempData["Blog"] = entity;
                return RedirectToAction("Index", "Home");

            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
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
