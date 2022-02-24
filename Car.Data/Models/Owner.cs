using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Models
{
    [Table("Owners")]
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }
    }
}
