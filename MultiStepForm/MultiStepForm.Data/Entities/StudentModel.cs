using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStepForm.Data.Entities
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

    }
}
