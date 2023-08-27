using LivingPokedexWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LivingPokedexWebsite.Data
{
    public class PokeDexDbContext : DbContext
    {
        public PokeDexDbContext(DbContextOptions options) : base(options)
        {
        }
            public DbSet<Pokemon> Pokemon { get; set; }
    }
}
