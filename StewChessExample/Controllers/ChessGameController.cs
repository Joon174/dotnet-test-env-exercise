using Microsoft.AspNetCore.Mvc;
using ChessGame.Services;
using ChessGame.Models;
using ChessGame.GameRequests;

namespace ChessGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessGameController : ControllerBase
    {
	private readonly ChessGameService _service;

	public ChessGameController(ChessGameService service)
	{
	    _service = service;
	}

	[HttpPost("start")]
	public async Task<ActionResult<ChessGameEvent>> StartNewGame([FromBody] StartGameReq request)
	{
	    var game = await _service.StartNewGameAsync(request.WhitePlayer, request.BlackPlayer);
	    return Ok(game);
	}

	[HttpPost("move/{gameId}")]
	public async Task<ActionResult> MovePiece(int gameId, [FromBody] MovePieceCommand command)
	{
            await _service.MovePieceEventAsync(gameId, command.Piece, command.From, command.To, command.Turn);
            return NoContent();
	}

	[HttpPost("history/{gameId}")]
	public async Task<ActionResult<List<PieceMoveEvent>>> GetMoveHistory(int gameId)
	{
	    var history = await _service.GetMoveHistoryAsync(gameId);
	    return Ok(history);
	}
    }
}
