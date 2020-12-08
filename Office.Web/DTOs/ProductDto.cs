using System;
using System.ComponentModel.DataAnnotations;

namespace Office.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is Required.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} value Should be Bigger than 1.")]
        public int Stock { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} value Should be Bigger than 1.")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
