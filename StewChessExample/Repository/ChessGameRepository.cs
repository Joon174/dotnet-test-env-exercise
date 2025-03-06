using Microsoft.EntityFrameworkCore;
using ChessGame.Data;
using ChessGame.Models;

namespace ChessGame.Repositories
{
    public class ChessGameRepository : IChessGameRepository
    {
	private readonly ChessGameDbContext _context;

	public ChessGameRepository(ChessGameDbContext context)
	{
	    _context = context;
	}

	public async Task<ChessGameEvent> GetGameByIdAsync(int gameId)
	{
	    return await _context.ChessGames.Include(g => g.PieceMoveEvents).FirstOrDefaultAsync(g => g.Id == gameId);
	}

	public async Task<ChessGameEvent> CreateAsync(string whitePlayer, string blackPlayer)
	{
	    var game = new ChessGameEvent
	    {
		WhitePlayerName = whitePlayer,
		BlackPlayerName = blackPlayer,
		StartTime = DateTime.UtcNow,
		PieceMoveEvents = new List<PieceMoveEvent>()
	    };

	    _context.ChessGames.Add(game);
	    await _context.SaveChangesAsync();
	    return game;
	}
    }
}
