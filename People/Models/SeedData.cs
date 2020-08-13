using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using People.Data;
namespace People.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(
            serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>()))
            {
                // Look for any movies.
                if (context.Nguoi.Any())
                {
                    return; // DB has been seeded
                }
                context.Nguoi.AddRange(
                new Nguoi {Name = "abc", Age = 9},
                new Nguoi {Name = "abcd", Age = 91},
                new Nguoi { Name = "abcde", Age = 92 },
                new Nguoi { Name = "abcdef", Age = 93 });
                context.SaveChanges();
            }
        }
    }
}
