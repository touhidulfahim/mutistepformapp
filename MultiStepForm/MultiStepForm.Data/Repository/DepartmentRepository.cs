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
    public class DepartmentRepository:IDepartment
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

        public DepartmentRepository(MultiStepFormAppDbContext context)
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

        public IEnumerable<DepartmentModel> GetDepartmentList()
        {
            return _context.DepartmentEntity.ToList();
        }

        public DepartmentModel DepartmentDetails(int? id)
        {
            return _context.DepartmentEntity.Find(id);
        }

        public void Insert(DepartmentModel departmentModel)
        {
            _context.DepartmentEntity.Add(departmentModel);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Update(DepartmentModel departmentModel)
        {
            _context.Entry(departmentModel).State = EntityState.Modified;
        }

        public void Remove(DepartmentModel departmentModel)
        {
            _context.DepartmentEntity.Remove(departmentModel);
        }
    }
}
