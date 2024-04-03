using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLsertifikalar> repo = new GenericRepository<TBLsertifikalar>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGüncelle(int id)
        {
          
            var deger=repo.Find(x=>x.ID==id);
            ViewBag.id = id;
            return View(deger);
        }
        [HttpPost]
        public ActionResult SertifikaGüncelle(TBLsertifikalar p) 
        { 
            var deger =repo.Find(x=>x.ID == p.ID);
            deger.Tarih=p.Tarih;
            deger.Sertifikalar=p.Sertifikalar;
            repo.TUpdate(deger);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YeniSertifika() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TBLsertifikalar p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id) 
        { 
           
            var sertifika= repo.Find(x=>x.ID==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
        
    }
}