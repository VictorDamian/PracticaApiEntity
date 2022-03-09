using Microsoft.EntityFrameworkCore;
using victorDamian.Models;

namespace victorDamian.Repositories
{
    public class ContextSong : DbContext
    {
        public ContextSong(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Song> Song { get; set; }
    }
}
