using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;

namespace PoC_NIP.Models
{
    public class PoC_NIP_DbContext : DbContext
    {
        public PoC_NIP_DbContext()
            : base("name=PoC_NIP_DbContext")
        {
        }
        public DbSet<Company> Companys { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}