using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWitter.Data
{
    public class CWitterContext : DbContext
    {
        public CWitterContext(DbContextOptions<CWitterContext> options)
            : base(options)
        { }

        public DbSet<Cweet> Cweets { get; set; }
    }

    public class Cweet
    {
        [Key]
        public string ID { get; set; }
        public string LicencePlate { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Author { get; set; }
    }
}
