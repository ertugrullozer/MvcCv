using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.sınıfım;
using System.IO;

namespace MvcCv.Controllers
{
    public class BlogEkleController : Controller
    {
        Card1Repository repo = new Card1Repository();
        Card2Repository repo2 = new Card2Repository();

        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            class1.tBLblogCard1s = repo.List();
            class1.tBLblogCard2s = repo2.List();

            return View(class1);
        }
        [HttpGet]
        public ActionResult Card1Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Card1Ekle([Bind(Include = "ID,Card1Resim,Card1Baslik,Card1AltBaslik,Card1Tarih,Card1Aciklama")] TBLblogCard1 p, HttpPostedFileBase yüklenecekDosya)
        {
           
            if (yüklenecekDosya !=null)
            {
                string dosyaYolu = Path.GetFileName(yüklenecekDosya.FileName);
                var yüklemeYeri = Path.Combine(Server.MapPath("~/BlogImage"), dosyaYolu);
                yüklenecekDosya.SaveAs(yüklemeYeri);
                p.Card1Resim = "/BlogImage/" + dosyaYolu;
              
            }

            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Card2Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Card2Ekle(TBLblogCard2 p)
        {
            repo2.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult Card1Sil(int id)
        {
            TBLblogCard1 t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        public ActionResult Card2Sil(int id)
        {
            TBLblogCard2 t = repo2.Find(x => x.ID == id);
            repo2.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Card1Güncelle(int id)
        {
            TBLblogCard1 t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Card1Güncelle(TBLblogCard1 p)
        {
            TBLblogCard1 t = repo.Find(x => x.ID == p.ID);
            t.Card1Resim = p.Card1Resim;
            t.Card1Baslik = p.Card1Baslik;
            t.Card1AtBaslik = p.Card1AtBaslik;
            t.Card1Tarih = p.Card1Tarih;
            t.Card1Aciklama = p.Card1Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Card2Güncelle(int id)
        {
            TBLblogCard2 t = repo2.Find(x => x.ID == id);

            return View(t);
        }
        [HttpPost]
        public ActionResult Card2Güncelle(TBLblogCard2 p)
        {
            TBLblogCard2 t = repo2.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Aciklama = p.Aciklama;
            repo2.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}