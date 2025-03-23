using DynamikFullstackChallengeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamikFullstackChallengeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Developer> Developers { get; set; }
    }
}
