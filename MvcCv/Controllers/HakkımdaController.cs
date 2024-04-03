using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda

        GenericRepository<TBLhakkinda> repo = new GenericRepository<TBLhakkinda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBLhakkinda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim=p.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}