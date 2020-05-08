using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Data.Context;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;

namespace MultiStepForm.Data.Repository
{
    public class MovieCategoryRepository:IMovieCategory
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

        public MovieCategoryRepository(MultiStepFormAppDbContext context)
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

        public void Insert(MovieCategory movieCategory)
        {
            _context.MovieCategoriesEntity.Add(movieCategory);
        }

        public List<MovieCategory> GetCategoryListByMovie(int? id)
        {
            return (from mc in _context.MovieCategoriesEntity
                    where mc.MovieId == id
                    select mc).ToList();
        }

        public List<MovieCategory> GetMovieCategory(int iD)
        {
            return _context.MovieCategoriesEntity.Where(m=>m.MovieId==iD).ToList();
        }

        public void Remove(MovieCategory mc)
        {
            _context.MovieCategoriesEntity.Remove(mc);
            _context.SaveChanges();
        }
    }
}
