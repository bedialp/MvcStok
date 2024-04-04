using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var values = db.TBLURUNLER.ToList();
            return View(values);
        }

        // URUN EKLEME ISLEMI
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> values = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString(),
                                           }).ToList();
            ViewBag.dgr = values;
            return  View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // URUN SILME ISLEMI 
        public ActionResult SIL(int id)
        {
            var values = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}