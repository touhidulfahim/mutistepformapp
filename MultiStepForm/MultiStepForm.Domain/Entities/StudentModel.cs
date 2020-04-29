using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiStepForm.Domain.Entities
{
    [Table("tb_Student")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string MobileNo { get; set; }
        public string RegistrationNo { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DepartmentModel DepartmentInfo { get; set; }
    }
}
