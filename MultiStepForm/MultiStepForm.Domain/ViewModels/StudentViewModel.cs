using System;
using System.ComponentModel.DataAnnotations;

namespace MultiStepForm.Domain.ViewModels
{
    public class StudentViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string RegistrationNo { get; set; }
    }
}
