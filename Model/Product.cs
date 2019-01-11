using System.ComponentModel.DataAnnotations;

namespace Elmah.Model
{
    public class Product
    {
        [Required]
        public string Name { get; set; }

        [Range(10, 20)]
        public int Quantity { get; set; }
    }
}
