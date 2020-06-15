using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Office.Core.Models
{
    public class Category
    {
        public Category()
        {
            // Default values
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        // One to Many Relationship for Entity Framework
        public ICollection<Product> Products { get; set; }
    }
}
