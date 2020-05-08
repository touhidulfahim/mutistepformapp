using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Domain.Interface
{
    public interface ICategory:IDisposable
    {
        IEnumerable<Category> GetCategoryList();
        Category GetCategoryDetails(int? id);
        void Insert(Category category);
        void Update(Category category);
        void Remove(Category category);
        void Commit();
    }
}
