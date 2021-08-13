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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTestApp.Data.RazorPagesTestAppContext _context;

        public DetailsModel(RazorPagesTestApp.Data.RazorPagesTestAppContext context)
        {
            _context = context;
        }

        public MovieModel MovieModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieModel = await _context.MovieModel.FirstOrDefaultAsync(m => m.Id == id);

            if (MovieModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
