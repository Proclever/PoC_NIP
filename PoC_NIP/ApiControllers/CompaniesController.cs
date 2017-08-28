using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PoC_NIP.Models;
using System.Text.RegularExpressions;

namespace PoC_NIP.ApiControllers
{
    public class CompaniesController : ApiController
    {
        private PoC_NIP_DbContext db = new PoC_NIP_DbContext();

        [ResponseType(typeof(Company))]
        [HttpGet]
        [ActionName("Search")]
        public async Task<IHttpActionResult> Search(string phrase)
        {
            Company company = null;
            if (phrase!=null && phrase !="")
            {
                Regex digitsonly = new Regex(@"[^\d]");
                var cleanphrase = digitsonly.Replace(phrase, "");
                foreach (var c in db.Companys.ToList())
                {
                    if (Equals(cleanphrase, digitsonly.Replace(c.Nip, "")) || Equals(phrase, c.Regon) || Equals(phrase, c.Krs))
                    {
                        company = c;
                        break;
                    }
                }
            }
            int? id = null;
            if (company != null) id = company.Id;
            var log = db.SearchLogs.Add(new SearchLog { CompanyFound = id, Created = DateTime.Now, Phrase = phrase, Found = id==null?false:true, HttpRequestHeaders = Request.Headers.ToString() });
            await db.SaveChangesAsync();
            if (company == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(company);
            }
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