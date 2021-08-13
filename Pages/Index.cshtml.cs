using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Data;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTestAppContext _context;

        public IndexModel(RazorPagesTestAppContext context)
        {
            _context = context;
        }

        public IList<MovieModel> MovieModel { get;set; }

        public async Task OnGetAsync()
        {
            MovieModel = await _context.MovieModel.ToListAsync();
        }
    }
}
