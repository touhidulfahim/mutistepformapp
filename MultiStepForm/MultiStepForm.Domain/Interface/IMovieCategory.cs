using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Domain.Interface
{
    public interface IMovieCategory:IDisposable
    {
        void Insert(MovieCategory movieCategory);
        List<MovieCategory> GetCategoryListByMovie(int? id);
        List<MovieCategory> GetMovieCategory(int iD);
        void Remove(MovieCategory mc);
    }
}
