using System.ComponentModel.DataAnnotations;

namespace Office.API.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

// ** Required : Customer should enter the value