using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Price
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Value Empty")]
        [Range(minimum: 0.10, maximum: float.MaxValue, ErrorMessage = "Price Invalid")]
        public float Value { get; set; }

        [Required(ErrorMessage = "Start Date Empty")]
        [DataType(DataType.DateTime, ErrorMessage = "Date only")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime, ErrorMessage = "Date only")]
        [DefaultValue(null)]
        public DateTime? EndDate { get; set; } = null;

        [DisplayName("Product")]
        [Required(ErrorMessage = "Product Empty")]
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
