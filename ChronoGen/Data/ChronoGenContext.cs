using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChronoGen.Models;

namespace ChronoGen.Data
{
    public class ChronoGenContext : DbContext
    {
        public ChronoGenContext (DbContextOptions<ChronoGenContext> options)
            : base(options)
        {
        }

        public DbSet<ChronoGen.Models.Watch> Watch { get; set; }
    }
}
