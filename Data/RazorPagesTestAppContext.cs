using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Data
{
    public class RazorPagesTestAppContext : DbContext
    {
        public RazorPagesTestAppContext (DbContextOptions<RazorPagesTestAppContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTestApp.Models.MovieModel> MovieModel { get; set; }
    }
}
