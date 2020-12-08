using System.ComponentModel.DataAnnotations;

namespace Office.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

// ** Required : Customer should enter the value