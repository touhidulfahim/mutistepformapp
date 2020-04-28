using System;
using System.Collections.Generic;
using MultiStepForm.Domain.ViewModels;

namespace MultiStepForm.Domain.Interface
{
    public interface IStudent:IDisposable
    {
        IEnumerable<StudentViewModel> GetStudentList();
        int? InsertStudent(StudentViewModel student);
        int? UpdateStudent(StudentViewModel student);
    }
}
