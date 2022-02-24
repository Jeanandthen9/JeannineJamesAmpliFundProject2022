using Car.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Context
{
    public class AmplifundProjectContext : DbContext
    {
        public AmplifundProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car.Data.Models.Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
