using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MultiStepForm.Data.Context;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;
using MultiStepForm.Domain.ViewModels;

namespace MultiStepForm.Data.Repository
{
    public class MovieRepository : IMovie
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

        public MovieRepository(MultiStepFormAppDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Movie GetMovieDetails(int? id)
        {
            return _context.MovieEntity.Find(id);
        }

        public IEnumerable<MovieViewModel> GetMovieList()
        {
            //return _context.MovieEntity.ToList();

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDbConnection"].ConnectionString))
                {
                    var movieList = con.Query<MovieViewModel>("select *from vGetMovieList", null).ToList();
                    return movieList;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Insert(Movie movie)
        {
            int result = -1;
            _context.MovieEntity.Add(movie);
            result = movie.ID;
            return result;
        }

        public void InsertMovieCategory(MovieCategory movieCategory)
        {
            _context.MovieCategoriesEntity.Add(movieCategory);
        }

        public int Update(Movie movie)
        {
            int result = -1;
            _context.Entry(movie).State = EntityState.Modified;
            result = movie.ID;
            return result;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void UpdateMovieCategory(MovieCategory movieCategory)
        {
            _context.Entry(movieCategory).State = EntityState.Modified;
        }
    }
}
