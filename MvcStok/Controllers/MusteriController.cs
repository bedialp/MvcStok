using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            var values = db.TBLMUSTERILER.ToList();
            return View(values);
        }

        // MUSTERI EKLEME ISLEMI
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // MUSTERI SILME ISLEMI 
        public ActionResult SIL(int id)
        {
            var values = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mstr);
        }
    }
}