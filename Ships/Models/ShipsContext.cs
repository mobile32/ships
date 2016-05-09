using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ships.Models
{
    public class ShipsContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}