using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStepForm.Domain.Entities
{
    [Table("tb_StudentCourse")]
    public class StudentCourseModel
    {
        [Key]
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime AssignDate { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentModel StudentInfo { get; set; }
        [ForeignKey("CourseId")]
        public virtual CourseInfoModel CourseInfo { get; set; }
    }
}
