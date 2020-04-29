using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Domain.Interface
{
    public interface ICourse:IDisposable
    {
        IEnumerable<CourseInfoModel> GetCourseList();
        CourseInfoModel GetCourseDetails(int? id);
        void Insert(CourseInfoModel courseInfoModel);
        bool Commit();
        void Update(CourseInfoModel courseInfoModel);
        void Remove(CourseInfoModel courseInfoModel);
    }
}
