using Microsoft.EntityFrameworkCore;
using ChessGame.Models;
                                                                                                                                                            namespace ChessGame.Data
{
    public class ChessGameDbContext : DbContext
    {
        public ChessGameDbContext(DbContextOptions<ChessGameDbContext> options) : base(options)
        {
        }

        public DbSet<ChessGameEvent> ChessGames { get; set; }
        public DbSet<PieceMoveEvent> PieceMoveEvents { get; set; }
    }
}    
