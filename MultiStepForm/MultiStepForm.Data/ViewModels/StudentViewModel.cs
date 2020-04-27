using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStepForm.Data.ViewModels
{
    public class StudentViewModel
    {
       
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
