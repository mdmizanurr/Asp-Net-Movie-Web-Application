using AspNetMovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace AspNetMovieApp.Controllers
{
    public class MoviesController: Controller
    {
        private MovieDBContext db = new MovieDBContext();


        public ActionResult Index()
        {
            IQueryable<string> genreQuery = from m in db.Movies 
                                            orderby m.Genre 
                                            select m.Genre;

            var movies = from m in db.Movies select m;


            return View(db.Movies.ToList());
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Price = movie.Price;

            return View(movie);

        }




        private bool MovieExists(int id)
        {
            return db.Movies.Any(e => e.ID == id);
        }


    }
}