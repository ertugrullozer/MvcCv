using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    //[Authorize] //login olmadan Controller açılmayacak
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBLegitimlerim> repo = new GenericRepository<TBLegitimlerim>();
        //[Authorize] //login olmadan index açılmayacak index açılmayacak
        public ActionResult Index()
        {
            var egitim = repo.List();
            
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLegitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim =repo.Find(x=>x.ID== id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDüzenle(int id) 
        { 
               var egitimDüzenle= repo.Find(x=>x.ID==id);
            return View(egitimDüzenle);
            
        }
        [HttpPost]
        public ActionResult EgitimDüzenle(TBLegitimlerim p)
        {
            var egitimDüzenle=repo.Find(x=>x.ID==p.ID);
            egitimDüzenle.Baslik=p.Baslik;
            egitimDüzenle.AltBaslik1 =p.AltBaslik1;
            egitimDüzenle.AltBaslik2=p.AltBaslik2; 
            egitimDüzenle.GNO=p.GNO;
            egitimDüzenle.Tarih = p.Tarih;
            repo.TUpdate(egitimDüzenle);
            return RedirectToAction("Index");
        }


    }
}