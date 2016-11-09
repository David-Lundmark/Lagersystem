using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagersystem.DataAccessLayer
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        {
        }

        public DbSet<Models.StockItem> Items { get; set; }
    }
}