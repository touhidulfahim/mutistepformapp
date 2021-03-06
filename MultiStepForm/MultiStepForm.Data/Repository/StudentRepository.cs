﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Data.Context;
using MultiStepForm.Domain.Interface;
using MultiStepForm.Domain.ViewModels;

namespace MultiStepForm.Data.Repository
{
    public class StudentRepository:IStudent
    {
        private readonly MultiStepFormAppDbContext _context;
        private bool _disposed = false;

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

        public IEnumerable<StudentViewModel> GetStudentList()
        {
            throw new NotImplementedException();
        }

        public int? InsertStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }

        public int? UpdateStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }
    }
}
