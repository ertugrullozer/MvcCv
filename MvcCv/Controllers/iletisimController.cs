using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TBLiletisim> repo = new GenericRepository<TBLiletisim>();
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
    }
}