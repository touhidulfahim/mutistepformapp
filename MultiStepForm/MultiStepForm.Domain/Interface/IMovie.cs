using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.ViewModels;

namespace MultiStepForm.Domain.Interface
{
    public interface IMovie:IDisposable
    {
        Movie GetMovieDetails(int? id);
        IEnumerable<MovieViewModel> GetMovieList();
        int Update(Movie movie);
        void Commit();
        int Insert(Movie movie);
        void InsertMovieCategory(MovieCategory movieCategory);
        void UpdateMovieCategory(MovieCategory movieCategory);
    }
}
