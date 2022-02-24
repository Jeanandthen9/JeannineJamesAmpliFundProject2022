using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }


        public int Year { get; set; }


        public string Color { get; set; }


        public bool IsConvertable { get; set; }
    }
}
