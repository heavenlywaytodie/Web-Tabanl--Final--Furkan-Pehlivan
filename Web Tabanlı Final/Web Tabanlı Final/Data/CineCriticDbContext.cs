using Microsoft.EntityFrameworkCore;
using Web_Tabanlı_Final.Models;

namespace Web_Tabanlı_Final.Data
{
    public class CineCriticDbContext : DbContext
    {
        public CineCriticDbContext(DbContextOptions<CineCriticDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}




