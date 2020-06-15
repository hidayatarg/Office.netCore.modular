using System;
namespace Office.Core.Models
{
    public class Product
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }

        // Connection to Category
        // One to Many Relationship for Entity Framework
        public virtual Category Category { get; set; }

    }
}
