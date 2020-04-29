using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStepForm.Domain.Entities
{
    [Table("tb_Address")]
    public class AddressModel
    {
        [Key]
        public int AddressId { get; set; }
        public int StudentId { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsMailing { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentModel StudentInfo { get; set; }
    }
}
