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
        // GET: BlogEkle

        //BlogEkleRepository repo=new BlogEkleRepository();

    
        Class1 cards = new Class1();
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            cards.tBLblogCard1s=db.TBLblogCard1.ToList();
            cards.tBLblogCard2s=db.TBLblogCard2.ToList();
            return View(cards);
        }
        [HttpGet]
        public ActionResult Card1Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Card1Ekle(TBLblogCard1 p)
        {
            //repo.TAdd(p);
            return RedirectToAction("Index");
        }

    }
}