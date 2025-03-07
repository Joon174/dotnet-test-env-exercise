using Microsoft.EntityFrameworkCore;
using ChessGame.Models;
using ChessGame.Repositories;

namespace ChessGame.Services
{
    public class ChessGameService : IChessGameService
    {
	// Holds all the events of a game
	private readonly IChessGameRepository _gameRepository;
	private readonly IPieceMoveEventRepository _moveEventRepository;

	public ChessGameService(IChessGameRepository gameRepository, IPieceMoveEventRepository moveEventRepository)
	{
	    _gameRepository = gameRepository;
	    _moveEventRepository = moveEventRepository;
	}

	public async Task<ChessGameEvent> StartNewGameAsync(string whitePlayer, string blackPlayer)
	{
	    return await _gameRepository.CreateAsync(whitePlayer, blackPlayer);
	}

	public async Task MovePieceEventAsync(int gameId, string piece, string fromPosition, string toPosition, string turn)
	{
	    var chessGame = await _gameRepository.GetGameByIdAsync(gameId);
	    if (chessGame == null)
	    {
		throw new Exception("Game does not exist");
	    }

	    var moveEvent = new PieceMoveEvent
	    {
		gameId = gameId,
		Piece = piece,
		FromPosition = fromPosition,
		ToPosition = toPosition,
		Turn = turn,
		Timestamp = DateTime.UtcNow
	    };

	    await _moveEventRepository.AddPieceMoveEventAsync(moveEvent);
	}

	public async Task<List<PieceMoveEvent>> GetMoveHistoryAsync(int gameId)
	{
	    var chessGame = await _gameRepository.GetGameByIdAsync(gameId);
	    if (chessGame == null)
	    {
	        throw new Exception("Game does not exist");
	    }

	    return await _moveEventRepository.GetMoveEventsByGameIdAsync(gameId);
	}
    }
}
