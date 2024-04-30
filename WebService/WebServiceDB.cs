using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebService
{
    public partial class WebServiceDB : DbContext
    {
        public WebServiceDB()
            : base("name=WebServiceDB")
        {
        }

        public virtual DbSet<WebServiceData> WebServiceDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
