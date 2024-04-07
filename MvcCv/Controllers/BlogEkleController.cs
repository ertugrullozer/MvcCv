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
        { Class1 class1 = new Class1();
            class1.tBLblogCard1s = repo.List();
            class1.tBLblogCard2s=repo2.List();
           
          return View(class1);
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

    }
}