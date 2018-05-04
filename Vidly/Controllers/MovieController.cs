using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = new Movies();

            return View(movie.movies);
        }

        public ActionResult Details(int id)
        {
            var movie = new Movies();
            var movieId = movie.movies.FirstOrDefault(a => a.id == id);

            if (movieId == null)

                return new HttpNotFoundResult();

            return Content(movieId.name);
        }
    }
}