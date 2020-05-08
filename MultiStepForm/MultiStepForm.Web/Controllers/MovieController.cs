using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;
using MultiStepForm.Domain.ViewModels;

namespace MultiStepForm.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovie _iMovie;
        private readonly ICategory _iCategory;
        private readonly IMovieCategory _iMovieCategory;


        public MovieController(IMovie iMovie, ICategory iCategory, IMovieCategory iMovieCategory)
        {
            _iMovie = iMovie;
            _iCategory = iCategory;
            _iMovieCategory = iMovieCategory;
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryList = _iCategory.GetCategoryList();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movieVM)
        {
            if (ModelState.IsValid)
            {
                //set the barcode
                //barcode objbar = new barcode();
                //byte[] img = objbar.getBarcodeImage(objbar.generateBarcode(), movie.Title);
                //movie.Barcode = objbar.generateBarcode();
                //movie.BarcodeImage = img;
                //join the array and convert to string to save in the database
//                string scat = string.Join(",", movie.SelectedCat);
//                movie.CategoryVal = scat;

                var movie = new Movie()
                {
                    Title = movieVM.Title,
                    ReleaseDate = movieVM.ReleaseDate,
                    Genre = movieVM.Genre,
                    Price = movieVM.Price,
                    Description = movieVM.Description,
                    Rating = movieVM.Rating,
                    Barcode = movieVM.Barcode,
                };

                int movieId =_iMovie.Insert(movie);
                if (movieId!=null)
                {
                    foreach (var scat in movieVM.SelectedCat)
                    {
                        var movieCategory = new MovieCategory()
                        {
                            MovieId = movieId,
                            CategoryId = scat
                        };
                        _iMovie.InsertMovieCategory(movieCategory);
                    }
                    _iMovie.Commit();
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _iCategory.GetCategoryList();
            return View(movieVM);
        }


        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Movie movie = _iMovie.GetMovieDetails(id);
            List<MovieCategory> categoryVal = _iMovieCategory.GetCategoryListByMovie(id);
            var scat = string.Join(",", categoryVal.Select(x => x.CategoryId));

            var movieVm = new MovieViewModel()
            {
                Title=movie.Title,
                Price=movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                Description = movie.Description,
                Rating = movie.Rating,
                Barcode = movie.Barcode
            };
            if (scat != null)
            {
                List<int> sl =scat.Split(',').Select(Int32.Parse).ToList();
                movieVm.SelectedCat = sl;
            }
            movieVm.MovieCategoryId = categoryVal.Select(m => m.MovieCategoryId).FirstOrDefault();
            //get the movie categories and bind with the model object
            ViewBag.CategoryList = _iCategory.GetCategoryList();

            if (movieVm == null)
            {
                return HttpNotFound();
            }
            return View(movieVm);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel movieVM)
        {
            var cat = _iCategory.GetCategoryList();
            if (movieVM.MovieCategoryId != 0)
            {
                List<MovieCategory> mc = _iMovieCategory.GetMovieCategory(movieVM.ID);
                //var count = mc.Select(m => m.MovieCategoryId).Count();
                foreach (var it in mc)
                {
                    _iMovieCategory.Remove(it);
                }
                //for (var i = 0; i < count; i++)
                //{
                //    _iMovieCategory.Remove(mc.ElementAt(i));
                //    count--;
                //}

            }

            //var count = mc.Categories.Count;
            //for (var i = 0; i < count; i++)
            //{
            //    art.Categories.Remove(art.Categories.ElementAt(i));
            //    count--;
            //}


            if (ModelState.IsValid)
            {
                var movie = new Movie()
                {
                    Title = movieVM.Title,
                    ReleaseDate = movieVM.ReleaseDate,
                    Genre = movieVM.Genre,
                    Price = movieVM.Price,
                    Description = movieVM.Description,
                    Rating = movieVM.Rating,
                    Barcode = movieVM.Barcode,
                    ID=movieVM.ID
                };
               int movieId= _iMovie.Update(movie);

                if (movieId != null)
                {
                    foreach (var scat in movieVM.SelectedCat)
                    {
                        var movieCategory = new MovieCategory()
                        {
                            MovieId = movieId,
                            CategoryId = scat
                        };
                        _iMovie.InsertMovieCategory(movieCategory);
                    }
                    _iMovie.Commit();
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _iCategory.GetCategoryList();
            return View(movieVM);
        }


        public ActionResult Index()
        {
            return View(_iMovie.GetMovieList());
        }
    }
}