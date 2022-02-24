using Car.Logic.Enums;

namespace Car.Logic.Models
{
    public class CarDataToViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Colors Color { get; set; }
        public bool IsConvertable { get; set; }
    }
}
