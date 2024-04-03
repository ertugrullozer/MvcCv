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
    public class SertifikaGaleriController : Controller
    {
        // GET: SertifikaGaleri
       

        GenericRepository<TBLsertifikaGaleri> repo = new GenericRepository<TBLsertifikaGaleri> ();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var galeriList = repo.List();
            return View(galeriList);
        }

        [HttpGet]
        public ActionResult Ekle() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult Ekle([Bind(Include = "ID,SertifikaResim")]TBLsertifikaGaleri p, HttpPostedFileBase yuklenecekDosya)
        {
            if (yuklenecekDosya != null)
            {
                string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Sertifika"), dosyaYolu);
                yuklenecekDosya.SaveAs(yuklemeYeri);
                p.SertifikaResim = "/Sertifika/" + dosyaYolu;

            }
            repo.TAdd(p);
            return View();
        }

    }
}