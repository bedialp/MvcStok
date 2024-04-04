using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa = 1)
        {
            // var values = db.TBLKATEGORILER.ToList();
            var values = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        // KATEGORI EKLEME ISLEMI
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // KATEGORI SILME ISLEMI 
        public ActionResult SIL(int id)
        {
            var values = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // KATEGORI GETIRME ISLEMI
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        // KATEGORI GUNCELLEME ISLEMI 
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}