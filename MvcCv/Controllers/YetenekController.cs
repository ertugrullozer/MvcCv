using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLyetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=>x.ID==id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Düzenle(int id)
        {
            var yetenekDüzenle = repo.Find(x=>x.ID==id);
            return View(yetenekDüzenle);
        }
        [HttpPost]
        public ActionResult Düzenle(TBLyetenekler p)
        {
            var yetenekDüzenle = repo.Find(x => x.ID == p.ID);
            yetenekDüzenle.Yetenek=p.Yetenek;
            yetenekDüzenle.Oran = p.Oran;
            repo.TUpdate(p); 
            return RedirectToAction("Index");
        }
    }
}