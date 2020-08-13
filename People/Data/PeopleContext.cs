using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using People.Models;

namespace People.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext (DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        public DbSet<People.Models.Nguoi> Nguoi { get; set; }
        public DbSet<People.Models.Movie> Movies { get; set; }
    }
}
