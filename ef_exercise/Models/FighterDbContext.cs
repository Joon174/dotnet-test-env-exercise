using Microsoft.EntityFrameworkCore;

namespace EFExercise.Models
{
    public class FighterDbContext : DbContext
    {
        public FighterDbContext(DbContextOptions<FighterDbContext> options) : base(options)
	{
	}

	public DbSet<Fighter> Fighters { get; set; }
    }
}
