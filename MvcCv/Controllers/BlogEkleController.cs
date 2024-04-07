using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.sınıfım;

namespace MvcCv.Controllers
{
    public class BlogEkleController : Controller
    {
        Card1Repository  repo = new Card1Repository();
        Card2Repository repo2 = new Card2Repository();
        public ActionResult Index()
        {
            var degerler = repo.List();
          return View(degerler);
        }
        [HttpGet]
        public ActionResult Card1Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Card1Ekle(TBLblogCard1 p)
        {
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

    }
}