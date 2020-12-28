using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;
namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILERs.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.dgr = degerler;





            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            
                db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var degerler = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id) 
        {
            var urun = db.TBLURUNLERs.Find(id);
            return View("UrunGetir",urun);
        
        }
        public ActionResult Guncelle (TBLURUNLER p1)
        {
            var urun = db.TBLURUNLERs.Find(p1.URUNID);//urunId ye gore yapilir
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.STOK = p1.STOK;
            urun.FIYAT = p1.FIYAT;
            urun.URUNKATEGORI = p1.URUNKATEGORI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}