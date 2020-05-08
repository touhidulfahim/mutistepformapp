using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MultiStepForm.Domain.ViewModels
{
    public class MovieViewModel
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        // [Display(Name = "Release Date"), DataType(DataType.Date)] //cover everything in one line
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        [AllowHtml]
        public string Description { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        public byte[] BarcodeImage { get; set; }
        public string Barcode { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryVal { get; set; }
        public IEnumerable<int> SelectedCat { get; set; }
        public string Category { get; set; }
        public int MovieCategoryId { get; set; }
    }
}
