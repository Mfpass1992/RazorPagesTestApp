using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTestApp.Data
{
    public class InitialData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RazorPagesTestAppContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesTestAppContext>>()))
            {
                if (context.MovieModel.Any())
                {
                    return;
                }

                context.MovieModel.AddRange
                    (
                        new MovieModel
                        {
                            Title = "Whiplash",
                            ReleaseDate = DateTime.Parse("2014-01-16"),
                            Genre = "Psychological drama",
                            Price = 10.99M
                        },
                        new MovieModel
                        {
                            Title = "GhostBusters",
                            ReleaseDate = DateTime.Parse("1984-03-13"),
                            Genre = "Comedy",
                            Price = 8.99M
                        },
                        new MovieModel
                        {
                            Title = "Twelve years a Slave",
                            ReleaseDate = DateTime.Parse("2013-08-30"),
                            Genre = "Historical drama",
                            Price = 15.99M
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
