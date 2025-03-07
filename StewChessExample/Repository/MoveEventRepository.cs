using Microsoft.EntityFrameworkCore;
using ChessGame.Data;
using ChessGame.Models;

namespace ChessGame.Repositories
{
    public class MoveEventRepository : IPieceMoveEventRepository
    {
	private readonly ChessGameDbContext _context;

	public MoveEventRepository(ChessGameDbContext context)
	{
	    _context = context;
	}

	public async Task AddPieceMoveEventAsync(PieceMoveEvent moveEvent)
	{
	    _context.PieceMoveEvents.Add(moveEvent);
	    await _context.SaveChangesAsync();
	}

	public async Task<List<PieceMoveEvent>> GetMoveEventsByGameIdAsync(int gameId)
	{
	    return await _context.PieceMoveEvents.Where(g => g.gameId == gameId).OrderBy(m => m.Timestamp).ToListAsync();
	}
    }
}
