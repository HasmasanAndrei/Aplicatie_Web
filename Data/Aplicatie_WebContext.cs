using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicatie_Web.Models;

namespace Aplicatie_Web.Data
{
    public class Aplicatie_WebContext : DbContext
    {
        public Aplicatie_WebContext (DbContextOptions<Aplicatie_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Aplicatie_Web.Models.Game> Game { get; set; }

        public DbSet<Aplicatie_Web.Models.Studio> Studio { get; set; }

        public DbSet<Aplicatie_Web.Models.Category> Category { get; set; }
    }
}
