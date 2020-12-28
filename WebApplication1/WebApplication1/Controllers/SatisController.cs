using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entity;
namespace WebApplication1.Controllers


{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
    [HttpGet]
    public ActionResult YeniSatis() {

            return View();
        
        }
    [HttpPost]
    public ActionResult YeniSatis(TBLSATISLAR p1)
        {
            db.TBLSATISLARs.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    
    
    }
}