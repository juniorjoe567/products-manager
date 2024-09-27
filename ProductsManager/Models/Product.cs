using ProductsManager.Validation;
using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        [NameValidation]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(2, 100, ErrorMessage ="Items in stock should be between 2 and 100")]
        public int ItemsInStock { get; set; }
    }
}
