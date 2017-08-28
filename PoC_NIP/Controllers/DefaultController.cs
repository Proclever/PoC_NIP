using PoC_NIP.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PoC_NIP.Controllers
{
    public class DefaultController : Controller
    {
        private PoC_NIP_DbContext db = new PoC_NIP_DbContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyList()
        {
            return View(db.Companys);
        }
        public ActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompany([Bind(Include = "Id,Nip,Regon,Krs,Name,Street,StreetNumber,PostalCode,City")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companys.Add(company);
                db.SaveChanges();
                return RedirectToAction("CompanyList");
            }

            return View(company);
        }
        
        public ActionResult EditCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompany([Bind(Include = "Id,Nip,Regon,Krs,Name,Street,StreetNumber,PostalCode,City")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CompanyList");
            }
            return View(company);
        }
        public ActionResult DeleteCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        [HttpPost, ActionName("DeleteCompany")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCompanyConfirmed(int id)
        {
            Company company = db.Companys.Find(id);
            foreach(var sl in company.SearchLog.ToList())
            {
                sl.CompanyFound = null;
            }
            db.SaveChanges();
            db.Companys.Remove(company);
            db.SaveChanges();
            return RedirectToAction("CompanyList");
        }
        public ActionResult LogList()
        {
            return View(db.SearchLogs);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}