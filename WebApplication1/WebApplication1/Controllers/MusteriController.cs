using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;
namespace WebApplication1.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Musteri
        public ActionResult Index(String p)
        {
            var degerler = from d in db.TBLMUSTERILERs select d;//linq

            if (!String.IsNullOrEmpty(p)) {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILERs.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges(); ;
            return View();

        }
        public ActionResult SIL(int id)
        {
            var deger = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILERs.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
            var ktg = db.TBLMUSTERILERs.Find(p1.MUSTERIID);
            ktg.MUSTERIAD = p1.MUSTERIAD;
            ktg.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }




    }
}