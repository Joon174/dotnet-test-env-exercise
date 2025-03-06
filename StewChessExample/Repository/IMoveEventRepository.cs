using ChessGame.Models;

namespace ChessGame.Repositories
{
    public interface IPieceMoveEventRepository
    {
	Task AddPieceMoveEventAsync(PieceMoveEvent moveEvent);
	Task<List<PieceMoveEvent>> GetMoveEventsByGameIdAsync(int gameId);
    }
}
