using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [RoutePrefix("movie")]

    public class MovieController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            //var movie = new CustomerStoreViewModel();

            var movies = _dbContext.movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.movies.Include(m => m.Genre).SingleOrDefault(a => a.id == id);

            if (movie == null)

                return new HttpNotFoundResult();

            return View(movie);
        }

        [HttpGet]
        [Route("new")]
        public ActionResult MovieForm()
        {
            var genre = _dbContext.genre.ToList();
            var viewModel = new MovieViewModel
            {
                genre = genre
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(MovieViewModel model)
        {
            try
            {
                var newEntity = Mapper.Map<Movies>(model);

                if (newEntity.id == 0)
                {
                    newEntity.DateAdded = DateTime.Now;
                    _dbContext.movies.Add(newEntity);
                }
                else
                {
                    var movieInDb = _dbContext.movies.Single(c => c.id == newEntity.id);
                    movieInDb.Name = newEntity.Name;
                    movieInDb.ReleasedDate = newEntity.ReleasedDate;
                    movieInDb.DateAdded = DateTime.Now;
                    movieInDb.GenreId = newEntity.GenreId;
                    movieInDb.NumberInStock = newEntity.NumberInStock;
                }
                 
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {

            }

            return RedirectToAction("Index", "Movie");

        }

        public ActionResult Edit(int id)
        {
            var movie = _dbContext.movies.SingleOrDefault(c => c.id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel
            {
                movie = movie,
                genre = _dbContext.genre.ToList()
            };

            return View("MovieForm", viewModel); //returns the customerForm view and the passed model
        }
    }
}