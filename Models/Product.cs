using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Empty")]
        [StringLength(80, ErrorMessage = "80 Characters Max")]
        [MinLength(5, ErrorMessage = "5 Character Min")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue(0)]
        [Required(ErrorMessage = "Stock Without Value")]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "Stock Invalid")]
        public int Stock { get; set; } = 0;

        public List<Price> Prices { get; set; } = new();
    }
}
