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
    public class CourseRepository:ICourse
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

        public CourseRepository(MultiStepFormAppDbContext context)
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

        public IEnumerable<CourseInfoModel> GetCourseList()
        {
            return _context.CourseInfoEntity.ToList();
        }

        public CourseInfoModel GetCourseDetails(int? id)
        {
            return _context.CourseInfoEntity.Find(id);
        }

        public void Insert(CourseInfoModel courseInfoModel)
        {
            _context.CourseInfoEntity.Add(courseInfoModel);
        }

        public bool Commit()
        {
            _context.SaveChanges();
            return true;
        }

        public void Update(CourseInfoModel courseInfoModel)
        {
            _context.Entry(courseInfoModel).State = EntityState.Modified;
        }

        public void Remove(CourseInfoModel courseInfoModel)
        {
            throw new NotImplementedException();
        }
    }
}
