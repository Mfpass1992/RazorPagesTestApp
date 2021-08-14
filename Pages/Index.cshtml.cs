using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<MovieModel> MovieModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        public SelectList genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string movieGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.MovieModel
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.MovieModel
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            MovieModel = await movies.ToListAsync();
        }
    }
}
