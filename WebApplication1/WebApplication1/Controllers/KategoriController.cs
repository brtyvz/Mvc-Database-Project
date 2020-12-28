using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;
using PagedList; 
    using PagedList.Mvc;
namespace WebApplication1.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKATEGORILERs.ToList().ToPagedList(sayfa, 2);//her sayfada 4 deger
            return View(degerler);
        }
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
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id) {
            var kategori = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    public ActionResult KategoriGetir(int id) {
            var ktgr = db.TBLKATEGORILERs.Find(id);
            return View("KategoriGetir", ktgr);
        }
    
        public ActionResult Guncelle(TBLKATEGORILER p1) 
        {
            var ktg = db.TBLKATEGORILERs.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }





    }
}