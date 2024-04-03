using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler =db.TBLhakkinda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler =db.TBLdeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLsosyalmedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Egitimlerim() 
        {
            var egitimlerim =db.TBLegitimlerim.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yeteneklerim() 
        {
            var yeteneklerim=db.TBLyetenekler.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobiler()
        {

            var hobilerim = db.TBLhobiler.ToList();
            return PartialView(hobilerim);

        }
        public PartialViewResult Sertifikar()
        {

           var deger =db.TBLsertifikalar.ToList();
            return PartialView(deger);

        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(TBLiletisim t)
        {
        
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLiletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }

    }
}