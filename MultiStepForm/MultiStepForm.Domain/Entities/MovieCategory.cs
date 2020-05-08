using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MultiStepForm.Domain.Entities
{
    [Table("tb_MovieCategory")]
    public class MovieCategory
    {
        [Key]
        public int MovieCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movies { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

    }
}
