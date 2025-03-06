namespace ChessGame.Models
{
    public class PieceMoveEvent
    {
	public int Id { get; set; }
	public string Piece { get; set; } = "Pawn";
	public string FromPosition { get; set; } = "e2";
	public string ToPosition { get; set; } = "e4";
	public string Turn { get; set; } = "1";
	public DateTime Timestamp { get; set; }
    }
}
