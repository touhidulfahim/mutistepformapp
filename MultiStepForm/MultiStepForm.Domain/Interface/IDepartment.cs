using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Domain.Interface
{
    public interface IDepartment:IDisposable
    {
        IEnumerable<DepartmentModel> GetDepartmentList();
        DepartmentModel DepartmentDetails(int? id);
        void Insert(DepartmentModel departmentModel);
        void Commit();
        void Update(DepartmentModel departmentModel);
        void Remove(DepartmentModel departmentModel);
    }
}
