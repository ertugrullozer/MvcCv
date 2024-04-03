using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TBLadmin> repo = new GenericRepository<TBLadmin>();

        public ActionResult Index()
        {
            var liste= repo.List();
            return View(liste);
        }

        public ActionResult AdminDüzenle() 
        {
            return View(); 
        
        }
        [HttpGet]
        public ActionResult AdminEkle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TBLadmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Düzenle(int id) 
        { 
            var düzen = repo.Find(x=>x.ID == id);
            return View(düzen);
        }
        [HttpPost]
        public ActionResult Düzenle(TBLadmin p) 
        {
            var düzen = repo.Find(x => x.ID == p.ID);
            düzen.KullaniciAdi=p.KullaniciAdi;
            düzen.Sifre=p.Sifre;
            repo.TUpdate(p);
            return RedirectToAction("Index");
            
        }

        public ActionResult AdminSil(int id)
        {
           var sil= repo.Find(x=>x.ID==id);
            repo.TDelete(sil);
            return RedirectToAction("Index");
        }
    }
}