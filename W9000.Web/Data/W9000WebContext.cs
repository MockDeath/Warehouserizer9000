using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W9000.Entities;

namespace W9000.Web.Models
{
    public class W9000WebContext : DbContext
    {
        public W9000WebContext (DbContextOptions<W9000WebContext> options)
            : base(options)
        {
        }

        public DbSet<W9000.Entities.FillOrder> FillOrder { get; set; }
    }
}
