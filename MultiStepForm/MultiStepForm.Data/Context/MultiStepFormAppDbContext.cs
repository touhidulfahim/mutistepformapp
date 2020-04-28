using System.Data.Entity;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Data.Context
{
    public class MultiStepFormAppDbContext:DbContext
    {
        public MultiStepFormAppDbContext():base("DefaultDbConnection")
        {
            
        }

        public IDbSet<StudentModel> StudentEntity { get; set; }


    }
}
