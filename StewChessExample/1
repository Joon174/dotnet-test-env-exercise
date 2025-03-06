using ChessGame.Models;

namespace ChessGame.Services
{
    public interface IChessGameService
    {
	Task<ChessGameEvent> StartNewGameAsync(string whitePlayer, string blackPlayer);
	Task MovePieceEventAsync(int gameId, string piece, string fromPosition, string toPosition, string turn);
	 Task<List<PieceMoveEvent>> GetMoveHistoryAsync(int gameId);
    }
}
