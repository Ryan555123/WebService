using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebService.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        WebServiceDB db = new WebServiceDB();

        // GET: Admin
        public ActionResult AdminIndex(string QueryStr)
        {
            List<WebServiceData> list = new List<WebServiceData>();

            if (QueryStr == null)
                list = db.WebServiceDatas.ToList();
            else
                list = db.WebServiceDatas.Where(m => m.Type.Contains(QueryStr) || m.IP.Contains(QueryStr) || m.XMLString.Contains(QueryStr)).ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WebServiceData WD)
        {
            if(ModelState.IsValid)
            {
                db.WebServiceDatas.Add(WD);
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View(WD);
        }

        public ActionResult Edit(int Id)
        {
            var Before_data = db.WebServiceDatas.Where(m => m.Id.Equals(Id)).FirstOrDefault();
            if(Before_data != null)
                return View(Before_data);
            else
                return View();
        }

        [HttpPost]
        public ActionResult Edit(WebServiceData WD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(WD).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("AdminIndex");
            }

            return View(WD);
        }

        public ActionResult Delete(int Id)
        {
            var Delete_data = db.WebServiceDatas.Where(m => m.Id.Equals(Id)).FirstOrDefault();

            db.WebServiceDatas.Remove(Delete_data);
            db.SaveChanges();
            return RedirectToAction("AdminIndex");
        }
    }
}