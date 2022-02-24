using Car.Logic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Car.UI.Models
{
    public class CarViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public int Year { get; set; }
        public Colors Color { get;set; }
        public bool IsConvertable { get; set; }
    }
}
