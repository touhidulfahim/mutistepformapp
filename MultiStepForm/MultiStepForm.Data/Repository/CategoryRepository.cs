using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Data.Context;
using MultiStepForm.Domain.Entities;
using MultiStepForm.Domain.Interface;

namespace MultiStepForm.Data.Repository
{
    public class CategoryRepository:ICategory
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

        public CategoryRepository(MultiStepFormAppDbContext context)
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

        public IEnumerable<Category> GetCategoryList()
        {
            return _context.CategoryEntity.ToList();
        }

        public Category GetCategoryDetails(int? id)
        {
            return _context.CategoryEntity.Find(id);
        }

        public void Insert(Category category)
        {
            _context.CategoryEntity.Add(category);
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Remove(Category category)
        {
            _context.CategoryEntity.Remove(category);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
