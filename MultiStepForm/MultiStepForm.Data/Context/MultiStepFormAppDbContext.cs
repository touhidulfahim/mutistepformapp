using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MultiStepForm.Domain.Entities;

namespace MultiStepForm.Data.Context
{
    public class MultiStepFormAppDbContext:DbContext
    {
        public MultiStepFormAppDbContext():base("DefaultDbConnection")
        {
            
        }

        public IDbSet<StudentModel> StudentEntity { get; set; }
        public IDbSet<AddressModel> AddressEntity { get; set; }
        public IDbSet<DepartmentModel> DepartmentEntity { get; set; }
        public IDbSet<CourseInfoModel> CourseInfoEntity { get; set; }
        public IDbSet<StudentCourseModel> StudentCourseEntity {get;set;}

        public IDbSet<Movie> MovieEntity { get; set; }
        public IDbSet<Category> CategoryEntity { get; set; }
        public IDbSet<MovieCategory> MovieCategoriesEntity { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        
    }
}
