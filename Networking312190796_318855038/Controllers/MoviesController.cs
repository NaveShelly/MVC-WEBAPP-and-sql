using Networking312190796_318855038.DalFolder;
using Networking312190796_318855038.Models;
using Networking312190796_318855038.ViewModel;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Networking312190796_318855038.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult addMovie()
        {
            return View("addMovie");
        }
        public ActionResult Submit(Movies tmp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dal dal = new Dal();
                    dal.movies.Add(tmp);
                    dal.SaveChanges();
                    Session["Result"] = "Movie Added!";
                }catch (DbUpdateException e)
                         when (e.InnerException?.InnerException is SqlException sqlEx &&
                            (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                        Session["Result"] = "There Was An Error Movie Not Added...";
                }
            }
            return View("addMovie");
        }
        public ActionResult SearchMovie()
        {
            return View("SearchMovie");
        }
        public ActionResult ShowSearch()
        {
            MoviesViewModel mvm = new MoviesViewModel();
            mvm.moviess = new List<Movies>();
            return View("SearchMovie",mvm);
        }
        public ActionResult SearchPriceIncrease()
        {
            Dal dal = new Dal();
            MoviesViewModel mvm = new MoviesViewModel();
            List<Movies> movies = new List<Movies>();
            movies = (from x in dal.movies where x.priceStatus.Contains("NotSale") select x).ToList();
            mvm.moviess = movies;
            return View("ShowSearch", mvm);
        }
        public ActionResult SearchPriceDecrease()
        {
            Dal dal = new Dal();
            MoviesViewModel mvm = new MoviesViewModel();
            List<Movies> movies = new List<Movies>();
            movies = (from x in dal.movies where x.priceStatus.Equals("Sale") select x).ToList();
            mvm.moviess = movies;
            return View("ShowSearch", mvm);
        }
        public ActionResult MostPopular()
        {
            Dal dal = new Dal();
            MoviesViewModel mvm = new MoviesViewModel();
            List<Movies> movies = new List<Movies>();
            movies = (from x in dal.movies where x.Popularity.Equals("Yes") select x).ToList();
            mvm.moviess = movies;
            return View("ShowSearch", mvm);
        }
        public ActionResult SearchMovies()
        {
            Dal dal = new Dal();
            string searchName = Request.Form["Name"].ToString();
            string searchDate = Request.Form["Date"].ToString();
            string searchTime = Request.Form["Hour"].ToString();
            string searchCategory = Request.Form["Category"].ToString();
            MoviesViewModel mvm = new MoviesViewModel();
            List<Movies> movies = new List<Movies>();
            if (searchName != "" && searchDate!= "" && searchTime!= "" && searchCategory != "")
            {
               movies = (from x in dal.movies where x.Name.Contains(searchName) && x.date.ToString().Contains(searchDate) && x.hour.Contains(searchTime) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if (searchName != "" && searchDate != "" && searchTime != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName)&& x.date.ToString().Contains(searchDate) && x.hour.Contains(searchTime) select x).ToList<Movies>();
            }
            if (searchName != "" && searchDate != "" && searchCategory != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName) && x.date.ToString().Contains(searchDate) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if ( searchDate != "" && searchTime != "" && searchCategory != "")
            {
                movies = (from x in dal.movies where x.date.ToString().Contains(searchDate) && x.hour.Contains(searchTime) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if (searchName != "" && searchDate != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName)&& x.date.ToString().Contains(searchDate) select x).ToList<Movies>();
            }
            if (searchName != "" &&  searchTime != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName) && x.hour.Contains(searchTime) select x).ToList<Movies>();
            }
            if (searchName != "" && searchCategory != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if (searchDate != "" && searchTime != "")
            {
                movies = (from x in dal.movies where x.date.ToString().Contains(searchDate) && x.hour.Contains(searchTime) select x).ToList<Movies>();
            }
            if (searchDate != "" && searchCategory != "")
            {
                movies = (from x in dal.movies where x.date.ToString().Contains(searchDate) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if (searchTime != "" && searchCategory != "")
            {
                movies = (from x in dal.movies where x.hour.Contains(searchTime) && x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            if (searchName != "")
            {
                movies = (from x in dal.movies where x.Name.Contains(searchName) select x).ToList<Movies>();
            }
            if (searchDate != "")
            {
                movies = (from x in dal.movies where x.date.ToString().Contains(searchDate) select x).ToList<Movies>();
            }
            if (searchTime != "")
            {
                movies = (from x in dal.movies where x.hour.Contains(searchTime) select x).ToList<Movies>();
            }
            if (searchCategory != "")
            {
                movies = (from x in dal.movies where x.Category.Contains(searchCategory) select x).ToList<Movies>();
            }
            mvm.moviess = movies;
            return View("ShowSearch", mvm);
        }
        public ActionResult MoviesGallery()
        {
            Dal dal = new Dal();
            List<Movies> movies = (from x in dal.movies select x).ToList<Movies>();
            MoviesViewModel mvm = new MoviesViewModel();
            mvm.moviess = movies;
            return View("MoviesGallery", mvm);
        }
        public ActionResult RemoveMovie()
        {
            return View("RemoveMovie");
        }
        public ActionResult Remove()
        {
            string searchName = Request.Form["Name"].ToString();
            string searchDate = Request.Form["Date"].ToString();
            string searchTime = Request.Form["Hour"].ToString();
            string searchHall = Request.Form["HallNum"].ToString();
            Dal dal = new Dal();
            List<Movies> movies = (from x in dal.movies where x.Name.Equals(searchName) && x.hour.Equals(searchTime) && x.date.Equals(searchDate) && x.HallNum.Equals(searchHall) select x).ToList<Movies>();
            if(movies.Count==1)
            {
                dal.movies.Remove(movies[0]);
                dal.SaveChanges();
                Session["Result"] = "Movie Removed!";
            }
            else
            {
                Session["Result"] = "No Movie Removed!";
            }
            return View("RemoveMovie");
        }
    }
}